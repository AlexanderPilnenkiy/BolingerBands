using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace BolingerBands.Source.Legend
{
    class Designations
    {
        public List<string> Time = new List<string>();
        public List<int> Open = new List<int>();
        public List<int> High = new List<int>();
        public List<int> Low = new List<int>();
        public List<int> Close = new List<int>();
        public List<double> RightLegend = new List<double>();
        public int Min, Max;

        public void ExportExcel()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.DefaultExt = "*.xls;*.xlsx";
            openDialog.Filter = "файл Excel (Spisok.xlsx)|*.xlsx";
            openDialog.Title = "Загрузка файла с данными";
            if (!(openDialog.ShowDialog() == DialogResult.OK)) { }
            var workbook = new XLWorkbook(openDialog.FileName);
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RangeUsed().RowsUsed();
            foreach (var row in rows)
            {
                Time.Add(row.Cell(1).Value.ToString());
                Open.Add(Convert.ToInt32(row.Cell(2).Value));
                High.Add(Convert.ToInt32(row.Cell(3).Value));
                Low.Add(Convert.ToInt32(row.Cell(4).Value));
                Close.Add(Convert.ToInt32(row.Cell(5).Value));
            }
            Max = High.Max();
            Min = Low.Min();
            GetRightLegend();
        }

        public void GetRightLegend()
        {
            for (int i = Min; i < Max; i += ((Max - Min) / 9))
            {
                RightLegend.Add(i);
            }
            RightLegend[9] = Max;
            RightLegend.Reverse();
        }
    }
}
