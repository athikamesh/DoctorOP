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
    /// Interaction logic for PaymentScreen.xaml
    /// </summary>
    public partial class PaymentScreen : Window
    {
        DOPEntities dOPEntities = new DOPEntities();
        public PaymentScreen(string visitid)
        {
            InitializeComponent();
            getrefdetail(visitid);
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void getrefdetail(string visitid)
        {
            try
            {
                var refdetail = dOPEntities.Payment_tbl.Where(b => b.patient_visitid == visitid).SingleOrDefault();
                if (refdetail != null)
                {
                    txt_patientID.Text = refdetail.patient_id;
                    txt_patientname.Text = refdetail.patient_name;
                    txt_med_amt.Text = refdetail.patient_med_amount;
                    txt_con_amt.Text = refdetail.patient_conslt_amount;
                    txt_tot_amt.Text = refdetail.patient_total_amount;
                    txt_mode.Text = refdetail.payment_mode;
                }
            }
            catch (Exception ex) { }
        }
    }
}
