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
    
    public partial class Governorate_Table
    {
        public Governorate_Table()
        {
            this.Arbitration_Table = new HashSet<Arbitration_Table>();
            this.Area_Table = new HashSet<Area_Table>();
            this.Consulting_Table = new HashSet<Consulting_Table>();
            this.Legal_Assistance_Table = new HashSet<Legal_Assistance_Table>();
            this.LegalIssues_Table = new HashSet<LegalIssues_Table>();
            this.Mediation_Table = new HashSet<Mediation_Table>();
            this.Order_Table = new HashSet<Order_Table>();
            this.SystemicIssues_Table = new HashSet<SystemicIssues_Table>();
        }
    
        public int Governorate_ID { get; set; }
        public string Governorate_Name { get; set; }
    
        public virtual ICollection<Arbitration_Table> Arbitration_Table { get; set; }
        public virtual ICollection<Area_Table> Area_Table { get; set; }
        public virtual ICollection<Consulting_Table> Consulting_Table { get; set; }
        public virtual ICollection<Legal_Assistance_Table> Legal_Assistance_Table { get; set; }
        public virtual ICollection<LegalIssues_Table> LegalIssues_Table { get; set; }
        public virtual ICollection<Mediation_Table> Mediation_Table { get; set; }
        public virtual ICollection<Order_Table> Order_Table { get; set; }
        public virtual ICollection<SystemicIssues_Table> SystemicIssues_Table { get; set; }
    }
}
