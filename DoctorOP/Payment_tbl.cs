//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoctorOP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment_tbl
    {
        public int Id { get; set; }
        public string paymentid { get; set; }
        public string patient_id { get; set; }
        public string patient_visitid { get; set; }
        public string patient_name { get; set; }
        public string patient_med_amount { get; set; }
        public string patient_conslt_amount { get; set; }
        public string patient_total_amount { get; set; }
        public string payment_mode { get; set; }
        public string payment_date { get; set; }
        public string nextvisit { get; set; }
    }
}
