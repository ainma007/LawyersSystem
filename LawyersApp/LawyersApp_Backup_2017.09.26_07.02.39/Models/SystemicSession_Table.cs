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
    
    public partial class SystemicSession_Table
    {
        public int SessionsID { get; set; }
        public Nullable<System.DateTime> SessionsDate { get; set; }
        public string Sessions_Decision { get; set; }
        public Nullable<int> SystemicIssuesID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string SessionsNumber { get; set; }
    
        public virtual SystemicIssues_Table SystemicIssues_Table { get; set; }
        public virtual Users_Table Users_Table { get; set; }
    }
}
