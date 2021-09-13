using DoctorOP.AutoComplete;
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
        List<DefaultClass.MedicinList> MList = new List<DefaultClass.MedicinList>();
        List<DefaultClass.MedicinList> AMList = new List<DefaultClass.MedicinList>();
        public PatientConsulting()
        {
            InitializeComponent();
           // dOPEntities.Database.Connection.ConnectionString = "data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=C:\\data\\DOP.mdf;";
            txt_patientID.Text = GetPateintID().ToString();           
            cmb_days.SelectedIndex = 0;
            LoadMedicin();
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
        int GetPaymentID()
        {
            int ID = 1000;
            var pid = dOPEntities.Payment_tbl.OrderByDescending(id => id.Id).ToList();
            if (pid.Count > 0)
            {
                ID = int.Parse(pid[0].patient_visitid) + 1;
            }

            return ID;
        }
        void LoadMedicin()
        {
            try
            {
                var data = dOPEntities.Medicin_tbl.ToList();
                foreach(var med in data)
                {
                    DefaultClass.MedicinList MDL = new DefaultClass.MedicinList();
                    MDL.med_Id = med.Med_Id;
                    MDL.med_name = med.Med_Name;
                    MDL.med_price = med.Med_Price;
                    MDL.med_type = med.Med_type;
                    MList.Add(MDL);
                }
                var medname = (from p in MList select p.med_name).Distinct().ToList();
                foreach (var ml in medname)
                {
                    txt_medicin_name.AddItem(new AutoCompleteEntry(ml, null));
                }
            }
            catch(Exception ex) { }
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
            pnl_od.IsEnabled = true;
            pnl_os.IsEnabled = false;
        }

        private void Rbt_os_Checked(object sender, RoutedEventArgs e)
        {
            eye = "OS";
            pnl_os.IsEnabled = true;
            pnl_od.IsEnabled = false;
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
                patientRefraction.patient_id = txt_patientID.Text;
                patientRefraction.patient_visitid = patientvisitid.ToString();
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
                if (i > 0) 
                { 
                    Tab2.IsSelected = true; 
                    txt_patientID_tab3.Text = txt_patientID.Text;
                    txt_patientname_tab3.Text = txt_patientname.Text;
                    rbt_female_tab3.IsChecked = rbt_female.IsChecked;
                    rbt_male_tab3.IsChecked = rbt_male.IsChecked;
                    rbt_other_tab3.IsChecked = rbt_other.IsChecked;
                    rbt_od_tab3.IsChecked = rbt_od.IsChecked;
                    rbt_os_tab3.IsChecked = rbt_os.IsChecked;
                    rbt_odos_tab3.IsChecked = rbt_odos.IsChecked;
                    txt_complaint_tab3.Text = cmb_ccomplaint.Text + txt_ocopmlaint.Text;
                }
            }
            catch (Exception EX) { }
        }

        private void defbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txt_customername_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_customername_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

        }

        private void Rbt_MOR_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Rbt_AFT_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Rbt_NGT_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Rbt_before_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Rbt_After_Checked(object sender, RoutedEventArgs e)
        {

        }
        int No=0;
        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var MedDet = dOPEntities.Medicin_tbl.Where(b => b.Med_Name == txt_medicin_name.Text).SingleOrDefault();
                if(MedDet!=null)
                {
                    No++;
                    DefaultClass.MedicinList DML = new DefaultClass.MedicinList();
                    DML.Id = No;
                    DML.med_Id = MedDet.Med_Id;
                    DML.med_name = MedDet.Med_Name;
                    DML.med_price = MedDet.Med_Price;
                    DML.med_type = MedDet.Med_type;
                    DML.med_qty = txt_qty.Text;
                    AMList.Add(DML);
                }
                Searchgrid.ItemsSource = AMList;
                txt_qty.Clear();
                txt_medicin_name.Text = "";
                txt_medicin_name.Focusable = true;
                txt_medicin_name.Focus();
                Searchgrid.Items.Refresh();
                Send(Key.Tab);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Txt_qty_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.Key==Key.Enter)
                {
                    Btn_add_Click(null, null);
                  
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Rbt_odos_Checked(object sender, RoutedEventArgs e)
        {
            eye = "ODOS";
            pnl_od.IsEnabled = true;
            pnl_os.IsEnabled = true;
        }

        private void Btn_tab3_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double amt = 0;
                foreach (var med in AMList)
                {
                    PatientSummary PS = new PatientSummary();
                    PS.patient_id = txt_patientID_tab3.Text;
                    PS.patient_visitid = patientvisitid.ToString();
                    PS.med_id = med.med_Id;
                    PS.med_name = med.med_name;


                    PS.med_qty = med.med_qty;
                    PS.med_Type = med.med_type;
                    PS.med_price = med.med_price;
                    amt += double.Parse(med.med_price);
                    PS.med_Amount = amt.ToString();
                    PS.create_date = DateTime.Now.ToString("dd-MM-yyyy");
                    dOPEntities.PatientSummary.Add(PS);                    
                }
                int i=dOPEntities.SaveChanges();
                if (i > 0) 
                { 
                    Tab3.IsSelected = true; Searchgrid1.ItemsSource = AMList;
                    txt_patientID_tab4.Text = txt_patientID.Text; 
                    txt_patientname_tab4.Text = txt_patientname.Text;
                    txt_med_amt_tab4.Text = amt.ToString();
                    txt_tot_amt_tab4.Text = (amt + double.Parse(txt_con_amt_tab4.Text)).ToString();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Btn_tab4_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Payment_tbl payment_Tbl = new Payment_tbl();
                payment_Tbl.patient_id = txt_patientID_tab4.Text;
                payment_Tbl.patient_name = txt_patientname_tab4.Text;
                payment_Tbl.patient_med_amount = txt_med_amt_tab4.Text;
                payment_Tbl.patient_conslt_amount = txt_con_amt_tab4.Text;             
                payment_Tbl.patient_visitid= patientvisitid.ToString();               
                payment_Tbl.patient_total_amount = txt_tot_amt_tab4.Text;
                payment_Tbl.payment_mode = "CASH";
                payment_Tbl.payment_date= DateTime.Now.ToString("dd-MM-yyyy");
                payment_Tbl.paymentid = GetPaymentID().ToString();
                dOPEntities.Payment_tbl.Add(payment_Tbl);
                int i = dOPEntities.SaveChanges();
                if (i > 0) 
                { 
                    Tab0.IsSelected = true;
                    Clear_Text();
                }
                
            }
            catch (Exception ex) { }
        }
        void Clear_Text()
        {
            //Tab0
            txt_patientID.Clear();
            txt_patientname.Clear();
            txt_mobile.Clear();
            txt_occupation.Clear();
            txt_address.Clear();
            txt_city.Clear();
            cmb_district.Text = "";
            txt_pincode.Clear();
            rbt_female.IsChecked = false;
            rbt_male.IsChecked = false;
            rbt_other.IsChecked = false;
            rbt_od.IsChecked = false;
            rbt_os.IsChecked = false;
            rbt_odos.IsChecked = false;
            cmb_ccomplaint.Text = "";
            txt_ocopmlaint.Clear();
            txt_searchpatient.Clear();
            txt_patientID.Text = GetPateintID().ToString();
            cmb_days.SelectedIndex = 0;
            //Tab1
            txt_SPH_OD.Clear();
            txt_CYL_OD.Clear();
            txt_AXIS_OD.Clear();
            txt_VISION_OD.Clear();
            txt_SPH_OS.Clear();
            txt_CYL_OS.Clear();
            txt_AXIS_OS.Clear();
            txt_VISION_OS.Clear();

            //Tab2
            txt_patientID_tab3.Clear();
            txt_patientname_tab3.Clear();
            rbt_female_tab3.IsChecked = false;
            rbt_male_tab3.IsChecked = false;
            rbt_other_tab3.IsChecked = false;
            rbt_od_tab3.IsChecked = false;
            rbt_os_tab3.IsChecked = false;
            rbt_odos_tab3.IsChecked = false;
            txt_complaint_tab3.Clear();
            cmb_days.SelectedIndex = 0;
            cmb_time.SelectedIndex = 0;
            txt_qty.Clear();
            txt_medicin_name.Text = "";
            Searchgrid.ItemsSource = null;
            AMList.Clear();
            //Tab3
            txt_patientID_tab4.Clear();
            txt_patientname_tab4.Clear();
            txt_med_amt_tab4.Clear();
            txt_con_amt_tab4.Clear();
            txt_tot_amt_tab4.Clear();
            Searchgrid1.ItemsSource = null;
        }
        public static void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                    {
                        RoutedEvent = Keyboard.KeyDownEvent
                    };
                    InputManager.Current.ProcessInput(e);

                    // Note: Based on your requirements you may also need to fire events for:
                    // RoutedEvent = Keyboard.PreviewKeyDownEvent
                    // RoutedEvent = Keyboard.KeyUpEvent
                    // RoutedEvent = Keyboard.PreviewKeyUpEvent
                }
            }
        }
    }
}
