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
        DOPEntities dOPEntities = new DOPEntities();

        public string _patientid;
        public string PatientId
        {
            get { return _patientid; }
            set { _patientid = value; }
        }
        public LastVisitControl()
        {
            InitializeComponent();
            var det = dOPEntities.GetPre_VisitDetail1(PatientId).ToList();

        }
    }
}
