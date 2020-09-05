using BolingerBands.Source.Services;
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
    public class DrawField : IPaint, IControlsDrawer
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
            for (int i = 0; i < mainWindow.Width - 150; i += 50)
            {
                DrawVerticalLine(mainWindow, i);
            }
            for (int i = 0; i < mainWindow.Height - 50; i += 50)
            {
                DrawHorizontalLine(mainWindow, i);
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
                Y2 = 400,
                Stroke = Brushes.LightGray
            };
            mainWindow.chartGrid.Children.Add(line);
        }

        public void DrawHorizontalLine(MainWindow mainWindow, int Y)
        {
            Line line = new Line()
            {
                StrokeDashArray = new DoubleCollection() { 10 },
                X1 = 0,
                Y1 = Y,
                X2 = 650,
                Y2 = Y,
                Stroke = Brushes.LightGray
            };
            mainWindow.chartGrid.Children.Add(line);
        }
    }
}
