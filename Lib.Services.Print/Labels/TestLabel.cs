﻿using Lib.Services.Print.Adapters;
using Lib.Services.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print.Labels
{
    /// <summary>
    /// Этот интерфейс должен быть реализован вьюмоделью, которая желает
    /// передавать команду печати данного вида этикетки
    /// </summary>
    public interface ITestLabelData
    {
        public string Text { get; set; }
        public int Barcode { get; set; }
    }

    public class TestLabel
    {
        public static void TscLib_W43xH25(string printerName, int productId, int sku, int? copy)
        {
            TscLibAdapter.Init(printerName);
            TscLibAdapter.SetLabelSize(SupportedLabelSizeEnum.W43xH25);
            TscLibAdapter.TextLine(25, 25, productId.ToString());
            TscLibAdapter.Code128(25, 85, 72, sku.ToString());
            TscLibAdapter.Print(copy);
        }
    }
}
