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

namespace DoctorOP.Control
{
    /// <summary>
    /// Interaction logic for LastVisitControl.xaml
    /// </summary>
    public partial class LastVisitControl : UserControl
    {
       

        public string _patientcomplaint;
        public string Patientcomplaint
        {
            get { return _patientcomplaint; }
            set { _patientcomplaint = value; lbl_complaint.Content = value; }
        }
        public string _visitdate;
        public string VisitDate
        {
            get { return _visitdate; }
            set { _visitdate = value;lbl_visitdate.Content = value; }
        }
        public string _eye;
        public string Eye
        {
            get { return _eye; }
            set { _eye = value; lbl_eye.Content = value; }
        }


        public LastVisitControl()
        {
            InitializeComponent();
          

        }
    }
}
