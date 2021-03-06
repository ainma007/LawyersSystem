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
    
    public partial class Media_Table
    {
        public int MediaID { get; set; }
        public string MediaName { get; set; }
        public Nullable<System.DateTime> MediaDate { get; set; }
        public string PartnerName { get; set; }
        public Nullable<int> MediaNumber { get; set; }
        public Nullable<int> minutes { get; set; }
        public string url { get; set; }
        public Nullable<int> MediaTypeID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual MediaType_Table MediaType_Table { get; set; }
        public virtual Project_Table Project_Table { get; set; }
        public virtual Users_Table Users_Table { get; set; }
    }
}
