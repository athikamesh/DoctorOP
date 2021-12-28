using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOP.DefaultClass
{
    class Patient_Class
    {
        public int Id { get; set; }
        public String patient_id { get; set; }
        public String patient_name { get; set; }
        public String patient_mobile { get; set; }
        public String patient_occupation { get; set; }
        public String patient_address { get; set; }
        public String patient_city { get; set; }
        public String patient_district { get; set; }
        public String patient_pincode { get; set; }
        public String Visitdate { get; set; }
    }
    class PatientVisit_Class
    {
        public int Id { get; set; }
        public String patient_visitid { get; set; }
        public String patient_id { get; set; }
        public String patient_name { get; set; }
        public String patient_mobile { get; set; }
        public String patient_city { get; set; }
        public String patient_Complaint { get; set; }
        public String patient_gender { get; set; }
        public String patient_eye { get; set; }
        public String patient_nextvisit { get; set; }
        public String Visitdate { get; set; }
    }
    class PatientMedicin_Class
    {
        public int Id { get; set; }
        public String patient_visitid { get; set; }
        public String patient_id { get; set; }
        public String patient_name { get; set; }
        public String medicin_name { get; set; }
        public String qty { get; set; }
        public String price { get; set; }
        public String Visitdate { get; set; }
    }
    class MedicinList
    {
        public int Id { get; set; }
        public String med_Id { get; set; }
        public String med_name { get; set; }
        public String med_price { get; set; }
        public String med_type { get; set; }
        public String med_qty { get; set; }
        public String med_total { get; set; }
    }
}
