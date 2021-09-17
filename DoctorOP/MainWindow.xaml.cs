using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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

namespace DoctorOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DOPEntities dOPEntities = new DOPEntities();
        public MainWindow()
        {
            InitializeComponent();
            LoadPieChart(); LoadColumnChart();
            PointLabel = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }
        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 4;
        }
        private void Btn_consulting_Click(object sender, RoutedEventArgs e)
        {
            PatientConsulting PC = new PatientConsulting();
            PC.ShowDialog();
        }

        void LoadPieChart()
        {
            var data = dOPEntities.Patientvisit.GroupBy(b=>b.patient_Complaint).ToList();
            foreach(var dat in data)
            {               
                PieSeries pieSeries = new PieSeries();
                pieSeries.Title = dat.Key.ToString();
                pieSeries.Values = new ChartValues<ObservableValue> { new ObservableValue(dat.Count()) };
                pieSeries.ToolTip = "New Idea1" + 20;
                pieSeries.DataLabels = true;
                anl_chart.Series.Add(pieSeries);
            }

            
        }
        void LoadColumnChart()
        {
            var data = dOPEntities.Payment_tbl.GroupBy(b => b.payment_date).ToList();

            foreach (var dat in data)
            {
                
                SeriesCollection = new SeriesCollection();
                ColumnSeries columnSeries = new ColumnSeries();
                columnSeries.Title = "";
                columnSeries.Values = new ChartValues<ObservableValue> { new ObservableValue(10) };
                columnSeries.DataLabels = true;
                SeriesCollection.Add(columnSeries);
                Labels = new [] { dat.Key.ToString()};
            }
            Formatter = value => value.ToString("N");

        }
        private void btn_medicin_Click(object sender, RoutedEventArgs e)
        {
            AddMedicin AMed = new AddMedicin();
            AMed.ShowDialog();
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
