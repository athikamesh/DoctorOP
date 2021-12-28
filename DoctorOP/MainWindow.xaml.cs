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
        public static DOCOPEntities dOPEntities = new DOCOPEntities();
        public MainWindow()
        {
            InitializeComponent();
            int ID = GetPateintID();
            frpage.Content = new PatientDetail();

        }
        public static int GetPateintID()
        {
            int ID = 1000;
            var pid = dOPEntities.PatientDetail.OrderByDescending(id => id.Id).ToList();
            if (pid.Count > 0)
            {
                ID = int.Parse(pid[0].patient_id) + 1;
            }

            return ID;
        }
        private void Btn_consulting_Click(object sender, RoutedEventArgs e)
        {
            PatientConsulting PC = new PatientConsulting();
            PC.ShowDialog();
           

        }

        private void Btn_medicin_Click(object sender, RoutedEventArgs e)
        {
            AddMedicin AM = new AddMedicin();
            AM.ShowDialog();
        }

      
        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
           
        }
       
        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
