using BolingerBands.Source.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            designations.ExportExcel();
            int k = 0;
            for (int i = 0; i < 500; i += 50)
            {
                GetValueLabel(mainWindow, i, designations.RightLegend[k].ToString());
                k++;
            }
            for (int i = 15; i < designations.Time.Count; i += 50)
            {
                GetDateLabel(mainWindow, i, designations.Time[i]);
            }
            designations.GetRightLegend();
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
                Margin = new Thickness(Settings.ChartWidth, Top + 5, 0, 0),
                Content = Caption,
                FontSize = 8
            };
            mainWindow.meshGrid.Children.Add(label);
        }
    }
}
