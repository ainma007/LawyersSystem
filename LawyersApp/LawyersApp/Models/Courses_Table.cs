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
    
    public partial class Courses_Table
    {
        public int CoursesID { get; set; }
        public string CoursesName { get; set; }
        public Nullable<System.DateTime> CoursesStartDate { get; set; }
        public Nullable<System.DateTime> CoursesEndDate { get; set; }
        public Nullable<int> TrainingHours { get; set; }
        public Nullable<int> TotalBeneficiaries { get; set; }
        public Nullable<int> Males { get; set; }
        public Nullable<int> Females { get; set; }
        public Nullable<int> TargetGroupID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ProjectID { get; set; }
    
        public virtual Users_Table Users_Table { get; set; }
        public virtual Project_Table Project_Table { get; set; }
        public virtual TargetGroup_Table TargetGroup_Table { get; set; }
    }
}
