using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
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
    /// Interaction logic for MedicinList.xaml
    /// </summary>
    public partial class MedicinList : Window
    {
        DOCOPEntities dOPEntities = new DOCOPEntities();
        List<DefaultClass.MedicinList> MList = new List<DefaultClass.MedicinList>();
        public MedicinList(string visitid)
        {
            InitializeComponent();
            LoadMedicin(visitid);
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void LoadMedicin(string visitid)
        {
            try
            {
                MList.Clear();int i = 0;
                Searchgrid.ItemsSource = null;
                var data = dOPEntities.PatientSummary.Where(b=>b.patient_visitid== visitid).ToList();
                foreach (var med in data)
                {
                    i++;
                    DefaultClass.MedicinList MDL = new DefaultClass.MedicinList();
                    MDL.Id = i;
                    MDL.med_Id = med.med_id;
                    MDL.med_name = med.med_name;
                    MDL.med_price = med.med_price;
                    MDL.med_type = med.med_Type;
                    MDL.med_qty = med.med_qty;
                    MDL.med_total = (Double.Parse(med.med_price) * double.Parse(med.med_qty)).ToString();
                    MList.Add(MDL);
                }
                Searchgrid.ItemsSource = MList;
            }
            catch (Exception ex) { }
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog OD = new OpenFileDialog();
                Nullable<bool> result = OD.ShowDialog();
                if (result == true)
                {
                    using (TextFieldParser parser = new TextFieldParser(OD.FileName))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        while (!parser.EndOfData)
                        {
                            //Processing row
                            string[] fields = parser.ReadFields();
                            foreach (string field in fields)
                            {
                                var det = dOPEntities.Medicin_tbl.Where(b => b.Med_Name == field[1].ToString()).FirstOrDefault();
                                if (det != null)
                                {
                                    int qty = int.Parse(det.Med_Qty);
                                    det.Med_Qty = (qty + int.Parse(field[4].ToString())).ToString();
                                    dOPEntities.SaveChanges();
                                }
                                else
                                {
                                    Medicin_tbl mtbl = new Medicin_tbl();
                                    mtbl.Med_Id = field[1].ToString();
                                    mtbl.Med_Name = field[2].ToString();
                                    mtbl.Med_Qty = field[3].ToString();
                                    mtbl.Med_Price = field[4].ToString();
                                    mtbl.Creat_Date = DateTime.Now.ToString("dd-MM-yyyy");
                                    dOPEntities.Medicin_tbl.Add(mtbl);
                                    dOPEntities.SaveChanges();
                                }
                            }
                        }
                    }
                }
                else { }
            }
            catch(Exception ex) { }
        }
    }
}
