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
    
    public partial class Advocacyactivities_Table
    {
        public int AdvocacyactivitiesID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> AdvocacyDate { get; set; }
        public string executingagency { get; set; }
        public string beneficiary { get; set; }
        public string GeographicArea { get; set; }
        public string url { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual Project_Table Project_Table { get; set; }
        public virtual Users_Table Users_Table { get; set; }
    }
}
