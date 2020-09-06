using BolingerBands.Source.Chart;
using BolingerBands.Source.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BolingerBands.Source.Legend
{
    class WriteLegend
    {
        public void Write(MainWindow mainWindow)
        {
            Designations designations = new Designations();
            DrawLines drawLines = new DrawLines();
            designations.ExportExcel();
            WriteDate(mainWindow, designations);
            WriteValues(mainWindow, designations);
            drawLines.Paint(mainWindow, designations);
        }

        void WriteDate(MainWindow mainWindow, Designations designations)
        {
            for (int i = 15; i < designations.Time.Count; i += 50)
            {
                GetDateLabel(mainWindow, i, designations.Time[i]);
            }
            designations.GetRightLegend();
        }

        void WriteValues(MainWindow mainWindow, Designations designations)
        {
            int k = 0;
            for (int i = 0; i < 500; i += 50)
            {
                GetValueLabel(mainWindow, i, designations.RightLegend[k].ToString());
                k++;
            }
        }

        void GetDateLabel(MainWindow mainWindow, int Left, string Caption)
        {
            Label label = new Label()
            {
                Margin = new Thickness(Left - 10, mainWindow.Height + 95, 0, 0),
                Content = Caption,
                FontSize = 8,
                RenderTransform = new RotateTransform(-90)
        };
            mainWindow.meshGrid.Children.Add(label);
        }

        void GetValueLabel(MainWindow mainWindow, int Top, string Caption)
        {
            Label label = new Label()
            {
                Margin = new Thickness(Settings.ChartWidth, Top, 0, 0),
                Content = Caption,
                FontSize = 8
            };
            mainWindow.meshGrid.Children.Add(label);
        }
    }
}
