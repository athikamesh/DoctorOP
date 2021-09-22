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
    /// Interaction logic for AddMedicin.xaml
    /// </summary>
    public partial class AddMedicin : Window
    {
        DOPEntities dOPEntities = new DOPEntities();
        public AddMedicin()
        {
            InitializeComponent();
            try
            {
                txt_medid.Text = GetPateintID().ToString();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        int GetPateintID()
        {
            
            int ID = 1000;
            var pid = dOPEntities.Medicin_tbl.OrderByDescending(id => id.Id).ToList();
            if (pid.Count > 0)
            {
                ID = int.Parse(pid[0].Med_Id) + 1;
            }
            return ID;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txt_medid.Text!="" && txt_medname.Text!="" && txt_medprice.Text!="" && txt_medqty.Text!="" && cmb_medtype.Text!="")
                {
                    Medicin_tbl medicin_Tbl = new Medicin_tbl();
                    medicin_Tbl.Med_Id = txt_medid.Text;
                    medicin_Tbl.Med_Name = txt_medname.Text;
                    medicin_Tbl.Med_Price = txt_medprice.Text;
                    medicin_Tbl.Med_Qty = txt_medqty.Text;
                    medicin_Tbl.Med_type = cmb_medtype.Text;
                    dOPEntities.Medicin_tbl.Add(medicin_Tbl);
                    int i=dOPEntities.SaveChanges();
                    if (i > 0) { MessageBox.Show("Added Successfully"); 
                        txt_medid.Text = "";
                        txt_medname.Text = "";
                        txt_medprice.Text = "";
                        txt_medqty.Text = "";
                        cmb_medtype.Text = "";
                        txt_medid.Text = GetPateintID().ToString();
                    } else { MessageBox.Show("Not Added Successfully"); }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              txt_medid.Text="";
              txt_medname.Text="";
              txt_medprice.Text="";
              txt_medqty.Text="";
              cmb_medtype.Text="";
              txt_medid.Text = GetPateintID().ToString();
            }
            catch (Exception ex) { }
        }
    }
}
