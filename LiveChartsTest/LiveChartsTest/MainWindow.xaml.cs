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

using LiveCharts;
using LiveCharts.Wpf;

namespace LiveChartsTest
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "robot 1",
                    Values = new ChartValues<double> { 24, 6, 5, 2 ,4, 12, 31, 8, 23, 28 },

                    PointForeground = Brushes.LightBlue,
                    Fill = Brushes.Transparent
                },
                new LineSeries
                {
                    Title = "robot 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6, 11, 11, 14, 19, 25 },
                    //PointGeometry = null

                    PointForeground = Brushes.LightCoral
                },
                new LineSeries
                {
                    Title = "robot 3",
                    Values = new ChartValues<double> { 4, 2, 7, 2, 7, 10, 18, 26, 31, 5},
                    //PointGeometry = DefaultGeometries.Square,
                    //PointGeometrySize = 15

                    PointForeground = Brushes.LightGoldenrodYellow
                }
            };

            LabelsTime = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            LabelsProduction = value => value.ToString();

            //modifying the series collection will animate and update the chart
            //SeriesCollection.Add(new LineSeries
            //{
            //    Title = "Series 4",
            //    Values = new ChartValues<double> { 5, 3, 2, 4 },
            //    LineSmoothness = 0, //0: straight lines, 1: really smooth lines
            //    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
            //    PointGeometrySize = 50,
            //    PointForeground = Brushes.Gray
            //});

            //modifying any series values will also animate and update the chart
            //SeriesCollection[3].Values.Add(5d);

            DataContext = this;
        }

        private void UpdateDatas_Click(object sender, RoutedEventArgs e)
        {
            //    SeriesCollection.Add(new LineSeries
            //    {
            //        Title = "Series 4",
            //        Values = new ChartValues<double> { 5, 3, 2, 4, 1, 3, 5, 7, 9, 10 },
            //        PointForeground = Brushes.Gray
            //    });

            //    SeriesCollection[3].Values.RemoveAt(0);

            //    SeriesCollection[3].Values.Add(5d);


            //double myNewValue = 0;
            //Random myRdm = new Random();
            //for (int i = 0; i < SeriesCollection.Count; i ++)
            //{
            //    // Create a random new value
            //    myNewValue = myRdm.Next(0, 100);

            //    // Add new value in "SeriesCollection"
            //    SeriesCollection[i].Values.RemoveAt(0);
            //    SeriesCollection[i].Values.Add(myNewValue);
            //}



            var myTask = Task.Run(() => MyUdpateChart(SeriesCollection));



            //SeriesCollection[0].Values.RemoveAt(0);
            //SeriesCollection[0].Values.Add(8d);

            //SeriesCollection[1].Values.RemoveAt(0);
            //SeriesCollection[1].Values.Add(12d);

            //SeriesCollection[2].Values.RemoveAt(0);
            //SeriesCollection[2].Values.Add(14d);
        }


        static void MyUdpateChart(SeriesCollection _SeriesCollection)
        {
            double myNewValue = 0;
            Random myRdm = new Random();
            for (int i = 1; i < _SeriesCollection.Count; i++)
            {
                // Create a random new value
                myNewValue = myRdm.Next(0, 100);

                // Add new value in "SeriesCollection"
                _SeriesCollection[i].Values.RemoveAt(0);
                _SeriesCollection[i].Values.Add(myNewValue);
            }
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] LabelsTime { get; set; }
        public Func<double, string> LabelsProduction { get; set; }
    }
}
