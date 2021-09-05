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
    /// Interaction logic for PatientConsulting.xaml
    /// </summary>
    public partial class PatientConsulting : Window
    {
        DOPEntities dOPEntities = new DOPEntities();
        string gender = "",eye=""; int patientvisitid = 0;
        public PatientConsulting()
        {
            InitializeComponent();
           // dOPEntities.Database.Connection.ConnectionString = "data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=C:\\data\\DOP.mdf;";
            txt_patientID.Text = GetPateintID().ToString();
        }
        int GetPateintID()
        {
            int ID = 1000;
            var pid = dOPEntities.PatientDetail.OrderByDescending(id=>id.Id).ToList();
            if(pid.Count>0)
            {
                ID = int.Parse(pid[0].patient_id)+1;
            }

            return ID;
        }
        int GetPateintVisitID()
        {
            int ID = 1000;
            var pid = dOPEntities.Patientvisit.OrderByDescending(id => id.Id).ToList();
            if (pid.Count > 0)
            {
                ID = int.Parse(pid[0].patient_visitid) + 1;
            }

            return ID;
        }
        private void Btn_tab1_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                patientvisitid = GetPateintVisitID();
                PatientDetail patientDetail = new PatientDetail();
                patientDetail.patient_id = txt_patientID.Text;
                patientDetail.patient_name = txt_patientname.Text;
                patientDetail.patient_mobile = txt_mobile.Text;
                patientDetail.patient_occupation = txt_occupation.Text;
                patientDetail.patient_address = txt_address.Text;
                patientDetail.patient_city = txt_city.Text;
                patientDetail.patient_district = cmb_district.Text;
                patientDetail.patient_pincode = txt_pincode.Text;
                patientDetail.Visitdate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");

                Patientvisit patientvisit = new Patientvisit();
                patientvisit.patient_visitid = patientvisitid.ToString();
                patientvisit.patient_id = txt_patientID.Text;
                patientvisit.patient_name = txt_patientname.Text;
                patientvisit.patient_gender = gender;
                patientvisit.patient_eye = eye;
                patientvisit.patient_Complaint = cmb_ccomplaint.Text + txt_occupation.Text;
                patientvisit.Visitdate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");

                dOPEntities.PatientDetail.Add(patientDetail);
                dOPEntities.Patientvisit.Add(patientvisit);
                int i=dOPEntities.SaveChanges();
                if (i > 0) { Tab1.IsSelected = true; }
            }
            catch(Exception ex) { }
        }

        private void Rbt_od_Checked(object sender, RoutedEventArgs e)
        {
            eye = "OD";
        }

        private void Rbt_os_Checked(object sender, RoutedEventArgs e)
        {
            eye = "OS";
        }

        private void Rbt_male_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Male";
        }

        private void Rbt_female_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Female";
        }

        private void Rbt_other_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Other";
        }

        private void Btn_tab2_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PatientRefraction patientRefraction = new PatientRefraction();
                patientRefraction.patient_id = patientvisitid.ToString();
                patientRefraction.SPH_OD = txt_SPH_OD.Text;
                patientRefraction.CYL_OD = txt_CYL_OD.Text;
                patientRefraction.AXIS_OD = txt_AXIS_OD.Text;
                patientRefraction.VISION_OD = txt_VISION_OD.Text;

                patientRefraction.SPH_OS = txt_SPH_OS.Text;
                patientRefraction.CYL_OS = txt_CYL_OS.Text;
                patientRefraction.AXIS_OS = txt_AXIS_OS.Text;
                patientRefraction.VISION_OS = txt_VISION_OS.Text;

                dOPEntities.PatientRefraction.Add(patientRefraction);
                int i = dOPEntities.SaveChanges();
                if (i > 0) { Tab2.IsSelected = true; }
            }
            catch (Exception EX) { }
        }

        private void Rbt_odos_Checked(object sender, RoutedEventArgs e)
        {
            eye = "ODOS";
        }
    }
}
