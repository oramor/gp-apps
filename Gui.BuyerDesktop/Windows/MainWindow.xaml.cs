using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace Gui.BuyerDesktop.Windows
{
    public class TscLibAdapter
    {
        #region Inner Methods

        [DllImport("TSCLIB.dll", EntryPoint = "about")]
        private static extern int about();

        [DllImport("TSCLIB.dll", EntryPoint = "openport")]
        private static extern int openport(string printername);

        [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
        private static extern int barcode(string x, string y, string type,
                    string height, string readable, string rotation,
                    string narrow, string wide, string code);

        [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
        private static extern int clearbuffer();

        [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
        private static extern int closeport();

        [DllImport("TSCLIB.dll", EntryPoint = "downloadpcx")]
        private static extern int downloadpcx(string filename, string image_name);

        [DllImport("TSCLIB.dll", EntryPoint = "formfeed")]
        private static extern int formfeed();

        [DllImport("TSCLIB.dll", EntryPoint = "nobackfeed")]
        private static extern int nobackfeed();

        [DllImport("TSCLIB.dll", EntryPoint = "printerfont")]
        private static extern int printerfont(string x, string y, string fonttype,
                        string rotation, string xmul, string ymul,
                        string text);

        [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
        private static extern int printlabel(string set, string copy);

        [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
        private static extern int sendcommand(string printercommand);

        [DllImport("TSCLIB.dll", EntryPoint = "setup")]
        private static extern int setup(string width, string height,
                  string speed, string density,
                  string sensor, string vertical,
                  string offset);

        [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
        private static extern int windowsfont(int x, int y, int fontheight,
                        int rotation, int fontstyle, int fontunderline,
                        string szFaceName, string content);
        [DllImport("TSCLIB.dll", EntryPoint = "windowsfontUnicode")]
        private static extern int windowsfontUnicode(int x, int y, int fontheight,
                         int rotation, int fontstyle, int fontunderline,
                         string szFaceName, byte[] content);

        [DllImport("TSCLIB.dll", EntryPoint = "sendBinaryData")]
        private static extern int sendBinaryData(byte[] content, int length);

        [DllImport("TSCLIB.dll", EntryPoint = "usbportqueryprinter")]
        private static extern byte usbportqueryprinter();

        #endregion

        public static void PrintStandardLabel(StandardLabelTask task)
        {
            _ = openport("TSC TTP-225");
            _ = setup(task.LabelWidth, task.LabelHeight, task.Speed, task.PrintDensity, task.Sensor.ToString(), task.VerticalGapHeight, task.GapDistance);
            _ = clearbuffer();
            _ = barcode(task.BarcodeStartPointX, task.BarcodeStartPointY, task.BarcodeFormat, task.BarcodeHeight, Convert.ToInt32(task.BarcodeTextIsAvailable).ToString(), task.BarcodeRotation.ToString(), task.BarcodeNarrowRatio, task.BarcodeWideRatio, task.BarcodeContent);
            _ = windowsfont(task.TextStartPointX, task.TextStartPointY, task.TextFontHeight, Convert.ToInt32(task.TextRotation), Convert.ToInt32(task.TextFontStyle), Convert.ToInt32(task.TextWithUnderline), task.TextFontFamilyName, task.TextContent);
            _ = printlabel(task.Sets.ToString(), task.Copy.ToString());
            _ = closeport();

        }
    }

    public enum RotationEnum
    {
        UpDown = 0,
        DownUp = 270,
    }

    public enum TextFontStyleEnum
    {
        Normal,
        Italic,
        Bold,
        BoldItalic
    }

    public enum PrintSensorEnum
    {
        VerticalGapSensor,
        BlackMarkSensor
    }

    // Label43x25ForTsc
    public class StandardLabelTask
    {
        // Setup
        public string LabelWidth { get; init; } = "43";
        public string LabelHeight { get; init; } = "25";
        public string Speed { get; init; } = "4";
        public string PrintDensity { get; init; } = "8";
        public PrintSensorEnum Sensor { get; init; } = PrintSensorEnum.VerticalGapSensor;
        public string VerticalGapHeight { get; init; } = "0.12";
        public string GapDistance { get; init; } = "0";

        // Barcode params
        public string BarcodeStartPointX { get; init; } = "25";
        public string BarcodeStartPointY { get; init; } = "85";
        public string BarcodeFormat { get; init; } = "128";
        public string BarcodeHeight { get; init; } = "72"; // In Pixels
        public bool BarcodeTextIsAvailable { get; init; } = true; // false => 0, true => 1 Текстовая интерпретация ШК
        public RotationEnum BarcodeRotation { get; init; } = RotationEnum.UpDown; // 0 90 180 270
        public string BarcodeNarrowRatio { get; init; } = "3";
        public string BarcodeWideRatio { get; init; } = "2";
        public string BarcodeContent { get; init; } = "0000000";

        // Label text params
        public int TextStartPointX { get; init; } = 25;
        public int TextStartPointY { get; init; } = 25;
        public int TextFontHeight { get; init; } = 40;
        public RotationEnum TextRotation { get; init; } = RotationEnum.DownUp;
        public TextFontStyleEnum TextFontStyle { get; init; } = TextFontStyleEnum.Bold;
        public bool TextWithUnderline { get; init; } = false; // false => 0
        public string TextFontFamilyName { get; init; } = "ARIAL";
        public string TextContent { get; init; } = "Test"; // Text to be printed

        // How many copies to print
        public int Sets { get; init; } = 1;
        public int Copy { get; init; } = 1;
    }

    public enum PrintLanguagesEnum
    {
        TSPL,
        EPL
    }

    public interface ICustomLabelTask
    {
        public string PrintLanguagesEnum { get; init; }
        public string Command { get; init; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var printTask = new StandardLabelTask() {
                TextContent = "Hello",
                BarcodeContent = "123456"
            };

            TscLibAdapter.PrintStandardLabel(printTask);


            //string alias = "ДСТ-555";
            //int cargoId = 457;

            //TscLibAdapter.openport("TSC TTP-225");
            //TscLibAdapter.setup("43", "25", "4", "8", "0", "0,12", "0");
            //TscLibAdapter.clearbuffer();
            //TscLibAdapter.barcode("25", "85", "128", "72", "1", "0", "3", "2", cargoId.ToString().PadLeft(6, '0'));
            //TscLibAdapter.windowsfont(25, 25, 40, 0, 2, 0, "ARIAL", alias);
            //TscLibAdapter.printlabel("1", "1");
            //TscLibAdapter.closeport();
        }
    }
}

