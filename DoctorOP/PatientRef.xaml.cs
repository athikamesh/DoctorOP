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
using System.Windows.Shapes;

namespace DoctorOP
{
    /// <summary>
    /// Interaction logic for PatientRef.xaml
    /// </summary>
    public partial class PatientRef : Window
    {
        DOPEntities dOPEntities = new DOPEntities();
        public PatientRef(string visitid)
        {
            InitializeComponent();
            getrefdetail(visitid);
        }

        private void btn_tab2_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void getrefdetail(string visitid)
        {
            try
            {
                var refdetail = dOPEntities.PatientRefraction.Where(b => b.patient_visitid == visitid).SingleOrDefault();
                if(refdetail!=null)
                {
                    txt_AXIS_OD.Text = refdetail.AXIS_OD;
                    txt_AXIS_OS.Text = refdetail.AXIS_OS;
                    txt_CYL_OD.Text = refdetail.CYL_OD;
                    txt_CYL_OS.Text = refdetail.CYL_OS;
                    txt_SPH_OD.Text = refdetail.SPH_OD;
                    txt_SPH_OS.Text = refdetail.SPH_OS;
                    txt_VISION_OD.Text = refdetail.VISION_OD;
                    txt_VISION_OS.Text = refdetail.VISION_OS;
                    
                }
            }
            catch(Exception ex) { }
        }
    }
}
