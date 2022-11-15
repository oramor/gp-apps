using System.Runtime.InteropServices;
using Lib.Core;

namespace Lib.Services.Print.Adapters
{
    public enum BarcodeTextModeEnum
    {
        Invisible,
        VisibleLeft,
        VisibleCenter,
        VisibleRight,
    }

    public enum RotationModeEnum
    {
        Up = 0,
        Right = 90,
        Down = 180,
        Left = 270,
    }

    public enum FontStyleEnum
    {
        Normal,
        Italic,
        Bold,
        BoldItalic
    }

    public static class TscLibAdapter
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

        public static void SendCommand(string command)
        {
            _ = sendcommand(command);
        }

        public static void Print(int? qty)
        {
            _ = printlabel("1", qty?.ToString() ?? "1");
            _ = closeport();
        }

        public static void SetLabelSize(SupportedLabelSizeEnum size)
        {
            _ = size switch {
                SupportedLabelSizeEnum.W43xH25 => sendcommand("SIZE 43 mm, 25 mm"),
                _ => throw new ArgumentException($"Unsupported label size code {size}"),
            };
        }

        public static void Code128(int pointX, int pointY, int height, string content)
        {
            var barcodeType = "128";
            var textMode = Convert.ToString((int)BarcodeTextModeEnum.VisibleLeft);
            var rotation = Convert.ToString((int)RotationModeEnum.Up);
            var narrow = "3";
            var wide = "2";

            _ = barcode(pointX.ToString(), pointY.ToString(), barcodeType, height.ToString(), textMode, rotation, narrow, wide, content);
        }

        public static void Init(string printerName)
        {
            int err;

            err = openport(printerName);
            err = sendcommand("SEED 4"); // For TTP225: 2 3 4 5
            err = sendcommand("DENSITY 8"); // Sets the printing darkness
            err = sendcommand("DIRECTION 1");
            //_ = sendcommand("SET TEAR ON");
            err = sendcommand("CODEPAGE UTF-8");
            err = clearbuffer();

            if (err != 0)
            {
                var node = new CultureNode() {
                    Ru_RU = "Ошибка при обращении к API драйвера TSC (TscDll)",
                    En_US = "The Error when TSC driver (TscDll) has been called"
                };

                throw new LocalizedException(node);
            } 
        }

        public static void TextLine(int pointX, int pointY, string content, int fontHeight = 40)
        {
            var underlineMode = 0; // without
            var fontFace = "ARIAL";
            var rotation = 0;
            var fontStyle = 2; // Bold

            int err;

            err = windowsfont(pointX, pointY, fontHeight, rotation, fontStyle, underlineMode, fontFace, content);

            if (err != 0)
            {
                var node = new CultureNode() {
                    Ru_RU = "TscDll: Ошибка при вызове команды печати текстовой строки.",
                    En_US = "TscDll: Got error when text line command has been called."
                };

                throw new LocalizedException(node);
            }
        }
    }
}
