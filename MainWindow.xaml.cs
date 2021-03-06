﻿using BolingerBands.Source.Chart;
using BolingerBands.Source.Legend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BolingerBands
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OnLoad();
        }

        void OnLoad()
        {
            DrawField drawField = new DrawField();
            drawField.Paint(this);
        }

        private void getChartLegeng_Click(object sender, RoutedEventArgs e)
        {
            WriteLegend writeLegend = new WriteLegend();
            writeLegend.Write(this);
        }
    }
}
