using System.Runtime.InteropServices;
using System.Windows;

namespace Gui.BuyerDesktop.Windows
{
    public class LabelPrinter
    {
        [DllImport("TSCLIB.dll", EntryPoint = "about")]
        public static extern int about();

        [DllImport("TSCLIB.dll", EntryPoint = "openport")]
        public static extern int openport(string printername);

        [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
        public static extern int barcode(string x, string y, string type,
                    string height, string readable, string rotation,
                    string narrow, string wide, string code);

        [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
        public static extern int clearbuffer();

        [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
        public static extern int closeport();

        [DllImport("TSCLIB.dll", EntryPoint = "downloadpcx")]
        public static extern int downloadpcx(string filename, string image_name);

        [DllImport("TSCLIB.dll", EntryPoint = "formfeed")]
        public static extern int formfeed();

        [DllImport("TSCLIB.dll", EntryPoint = "nobackfeed")]
        public static extern int nobackfeed();

        [DllImport("TSCLIB.dll", EntryPoint = "printerfont")]
        public static extern int printerfont(string x, string y, string fonttype,
                        string rotation, string xmul, string ymul,
                        string text);

        [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
        public static extern int printlabel(string set, string copy);

        [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
        public static extern int sendcommand(string printercommand);

        [DllImport("TSCLIB.dll", EntryPoint = "setup")]
        public static extern int setup(string width, string height,
                  string speed, string density,
                  string sensor, string vertical,
                  string offset);

        [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
        public static extern int windowsfont(int x, int y, int fontheight,
                        int rotation, int fontstyle, int fontunderline,
                        string szFaceName, string content);
        [DllImport("TSCLIB.dll", EntryPoint = "windowsfontUnicode")]
        public static extern int windowsfontUnicode(int x, int y, int fontheight,
                         int rotation, int fontstyle, int fontunderline,
                         string szFaceName, byte[] content);

        [DllImport("TSCLIB.dll", EntryPoint = "sendBinaryData")]
        public static extern int sendBinaryData(byte[] content, int length);

        [DllImport("TSCLIB.dll", EntryPoint = "usbportqueryprinter")]
        public static extern byte usbportqueryprinter();
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

    public interface IStandardLabelTask
    {
        // Barcode params
        public int BarcodeStratPointX { get; init; } // 25
        public int BarcodeStratPointY { get; init; } // 85
        public string BarcodeFormat { get; init; } // 128
        public int BarcodeHeight { get; init; } // In Pixels, 72
        public bool IsTextPrint { get; init; } // false => 0, true => 1 Текстовая интерпретация ШК
        public RotationEnum BarcodeRotation { get; init; } // 0 90 180 270
        public int NarrowBarRatio { get; init; } // 3
        public int WideBarRatio { get; init; } // 2
        public string BarcodeContent { get; init; }

        // Label text params
        public int TextStratPointX { get; init; } // 25
        public int TextStratPointY { get; init; } // 25
        public int TextFontHeight { get; init; } // 40
        public RotationEnum TextRotation { get; init; } // 0
        public TextFontStyleEnum TextFontStyle { get; init; } // 2
        public bool TextWithUnderline { get; init; } // false => 0
        public string TextFontFamilyName { get; init; } // ARIAL
        public string TextContent { get; init; } // Text to be printed

        // How many copies to print
        public int Copy { get; init; }
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
            string alias = "ДСТ-555";
            int cargoId = 457;

            LabelPrinter.openport("TSC TTP-225");
            LabelPrinter.setup("43", "25", "4", "8", "0", "0,12", "0");
            LabelPrinter.clearbuffer();
            LabelPrinter.barcode("25", "85", "128", "72", "1", "0", "3", "2", cargoId.ToString().PadLeft(6, '0'));
            LabelPrinter.windowsfont(25, 25, 40, 0, 2, 0, "ARIAL", alias);
            LabelPrinter.printlabel("1", "1");
            LabelPrinter.closeport();
        }
    }
}

