using BolingerBands.Source.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BolingerBands.Source.Chart
{
    public class DrawField
    {
        public void Paint(MainWindow mainWindow)
        {
            DrawMesh(mainWindow);
            DrawRectangle(mainWindow);
        }

        public void DrawRectangle(MainWindow mainWindow)
        {
            Rectangle rectangle = new Rectangle()
            {
                Stroke = Brushes.Black,
            };
            mainWindow.chartGrid.Children.Add(rectangle);
        }

        public void DrawMesh(MainWindow mainWindow)
        {
            int Max = Settings.ChartWidth, Step = 50;
            for (int i = 0; i < Max; i += Step)
            {
                DrawLine(mainWindow, i, i, 0, mainWindow.Height);            //vertical
            }
            for (int i = 15; i < 500; i += Step)
            {
                DrawLine(mainWindow, 0, Max, i, i);                          //horizontal
            }
        }

        public void DrawLine(MainWindow mainWindow, int X1, int X2, int Y1, double Y2)
        {
            Line line = new Line()
            {
                StrokeDashArray = new DoubleCollection() { 10 },
                X1 = X1,
                Y1 = Y1,
                X2 = X2,
                Y2 = Y2,
                Stroke = Brushes.LightGray
            };
            mainWindow.meshGrid.Children.Add(line);
        }
    }
}
