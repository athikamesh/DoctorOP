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
        public string _sph_od;
        public string SPH_OD
        {
            get { return _sph_od; }
            set { _sph_od = value; txt_SPH_OD.Text = value; }
        }
        public string _cyl_od;
        public string CYL_OD
        {
            get { return _cyl_od; }
            set { _cyl_od = value; txt_CYL_OD.Text = value; }
        }
        public string _axis_od;
        public string AXIS_OD
        {
            get { return _axis_od; }
            set { _axis_od = value; txt_AXIS_OD.Text = value; }
        }
        public string _vision_od;
        public string VISION_OD
        {
            get { return _vision_od; }
            set { _vision_od = value; txt_VISION_OD.Text = value; }
        }
        public string _sph_os;
        public string SPH_OS
        {
            get { return _sph_os; }
            set { _sph_os = value; txt_SPH_OS.Text = value; }
        }
        public string _cyl_os;
        public string CYL_OS
        {
            get { return _cyl_os; }
            set { _cyl_os = value; txt_CYL_OS.Text = value; }
        }
        public string _axis_os;
        public string AXIS_OS
        {
            get { return _axis_os; }
            set { _axis_os = value; txt_AXIS_OS.Text = value; }
        }
        public string _vision_os;
        public string VISION_OS
        {
            get { return _vision_os; }
            set { _vision_os = value; txt_VISION_OS.Text = value; }
        }
        public string _meddetail;
        public string Meddetail
        {
            get { return _meddetail; }
            set { _meddetail = value; txt_medicin.Text = value; }
        }
        public LastVisitControl()
        {
            InitializeComponent();
          

        }
    }
}
