﻿using LiveCharts;
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
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            LoadPayment_Chart(); VisitCount(); PaymentCount();
        }

        private void Btn_consulting_Click(object sender, RoutedEventArgs e)
        {
            PatientConsulting PC = new PatientConsulting();
            PC.ShowDialog();
            LoadPayment_Chart(); VisitCount(); PaymentCount();
            CChart.
        }

        private void Btn_medicin_Click(object sender, RoutedEventArgs e)
        {

        }

        void LoadPayment_Chart()
        {
            try
            {
                              
                var detail = dOPEntities.SumProcedure().ToList();
                SeriesCollection = new SeriesCollection();
                Labels = new string[detail.Count];int i = 0;
                ChartValues<double> CV = new ChartValues<double>();
                foreach (var det in detail)
                {                  
                    CV.Add(Convert.ToDouble(det.Sumtotal));
                    Labels[i] = det.payment_date;                              
                    i++;
                }
                ColumnSeries columnSeries = new ColumnSeries();
                columnSeries.Values = CV;
                SeriesCollection.Add(columnSeries);
                Formatter = value => value.ToString("N");
                
                DataContext = this;

            }
            catch(Exception ex) { }
        }

        void VisitCount()
        {
            string tdate = DateTime.Now.ToString("dd-MM-yyyy");
            var totvisit = dOPEntities.Patientvisit.Count();
            var todayvisit = dOPEntities.Patientvisit.Where(b => b.Visitdate.Contains(tdate)).Count();
            lbl_today_visit.Content = todayvisit;
            lbl_total_visit.Content = totvisit;
        }
        void PaymentCount()
        {
            string tdate = DateTime.Now.ToString("dd-MM-yyyy");
            var totamount = dOPEntities.SumProcedure().Sum(b=>b.Sumtotal);
            var todayamount = dOPEntities.SumProcedure().Where(b => b.payment_date == tdate).SingleOrDefault();
            lbl_today_pay.Content = totamount;
            if (todayamount == null) { lbl_total_pay.Content = "0"; }
            else { lbl_total_pay.Content = todayamount.Sumtotal; }
        }
    }
}
