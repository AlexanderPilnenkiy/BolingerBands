using BolingerBands.Source.Configs;
using BolingerBands.Source.Legend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BolingerBands.Source.Chart
{
    class DrawLines
    {
        public async void Paint(MainWindow mainWindow, Designations designations)
        {
            double Range = designations.Max - designations.Min;
            int FieldHeight = Settings.ChartHeight - 35;
            for (int i = 0; i < designations.High.Count - 1; i++)
            {
                double Y1High = FieldHeight - FieldHeight / (Range / (designations.High[i + 1] - designations.Min));
                double Y2High = FieldHeight - FieldHeight / (Range / (designations.High[i] - designations.Min));
                await DrawLine(mainWindow, i, i + 1, Y1High, Y2High, Brushes.Red);
                double Y1Low = FieldHeight - FieldHeight / (Range / (designations.Low[i + 1] - designations.Min));
                double Y2Low = FieldHeight - FieldHeight / (Range / (designations.Low[i] - designations.Min));
                await DrawLine(mainWindow, i, i + 1, Y1Low, Y2Low, Brushes.Green);
                double Y1Middle = FieldHeight - FieldHeight / (Range / (designations.High[i + 1] - (designations.High[i + 1] - designations.Low[i + 1]) 
                    / 2 - designations.Min));
                double Y2Middle = FieldHeight - FieldHeight / (Range / (designations.High[i] - (designations.High[i] - designations.Low[i])
                    / 2 - designations.Min));
                await DrawLine(mainWindow, i, i + 1, Y1Middle, Y2Middle, Brushes.Blue);
            }
        }

        public async Task<int> DrawLine(MainWindow mainWindow, int X1, int X2, double Y1, double Y2, Brush brushes)
        {
            Line line = new Line()
            {
                X1 = X1,
                Y1 = Y1,
                X2 = X2,
                Y2 = Y2,
                Stroke = brushes
            };
            mainWindow.meshGrid.Children.Add(line);
            return 0;
        }
    }
}
