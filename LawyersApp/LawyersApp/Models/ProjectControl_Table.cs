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
    
    public partial class ProjectControl_Table
    {
        public int ProjectControlID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual Project_Table Project_Table { get; set; }
        public virtual Users_Table Users_Table { get; set; }
    }
}
