//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LawyersApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mediation_Table
    {
        public int MediationID { get; set; }
        public string MediationNumber { get; set; }
        public Nullable<System.DateTime> MediationDate { get; set; }
        public string FirstSideName { get; set; }
        public string FirstSideIDNumber { get; set; }
        public string FirstSidePhone { get; set; }
        public string FirstSocialstatus { get; set; }
        public string FirstSideAddress { get; set; }
        public string SecondSideName { get; set; }
        public string SecondSideIDNumber { get; set; }
        public string SecondSidePhone { get; set; }
        public string SecondSocialstatus { get; set; }
        public string SecondSideAddress { get; set; }
        public string MediatorName { get; set; }
        public string MediatorPhone { get; set; }
        public string Agreement { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual Users_Table Users_Table { get; set; }
    }
}
