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
    
    public partial class TypeOfCase_Table
    {
        public TypeOfCase_Table()
        {
            this.Consulting_Table = new HashSet<Consulting_Table>();
            this.LegalIssues_Table = new HashSet<LegalIssues_Table>();
            this.SystemicIssues_Table = new HashSet<SystemicIssues_Table>();
        }
    
        public int TypeOfCase_ID { get; set; }
        public string TypeOfCaseName { get; set; }
        public Nullable<int> IssuesTypeID { get; set; }
    
        public virtual ICollection<Consulting_Table> Consulting_Table { get; set; }
        public virtual IssuesType_Table IssuesType_Table { get; set; }
        public virtual ICollection<LegalIssues_Table> LegalIssues_Table { get; set; }
        public virtual ICollection<SystemicIssues_Table> SystemicIssues_Table { get; set; }
    }
}
