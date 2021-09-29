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
                    MList.Add(MDL);
                }
                Searchgrid.ItemsSource = MList;
            }
            catch (Exception ex) { }
        }
    }
}
