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
            for (int i = 15; i < Max; i += Step)
            {
                DrawVerticalLine(mainWindow, i);
            }
            for (int i = 15; i < 500; i += Step)
            {
                DrawHorizontalLine(mainWindow, i, Max);
            }
        }

        public void DrawVerticalLine(MainWindow mainWindow, int X)
        {
            Line line = new Line()
            {
                StrokeDashArray = new DoubleCollection() { 10 },
                X1 = X,
                Y1 = 0,
                X2 = X,
                Y2 = mainWindow.Height,
                Stroke = Brushes.LightGray
            };
            mainWindow.meshGrid.Children.Add(line);
        }

        public void DrawHorizontalLine(MainWindow mainWindow, int Y, int X2)
        {
            Line line = new Line()
            {
                StrokeDashArray = new DoubleCollection() { 10 },
                X1 = 0,
                Y1 = Y,
                X2 = X2,
                Y2 = Y,
                Stroke = Brushes.LightGray
            };
            mainWindow.meshGrid.Children.Add(line);
        }
    }
}
