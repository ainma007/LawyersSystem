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
    
    public partial class FamilyForum_Table
    {
        public int FamilyForumID { get; set; }
        public string FamilyForumNumber { get; set; }
        public Nullable<System.DateTime> ViewingDate { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantPhone { get; set; }
        public string ApplicantSocialStatus { get; set; }
        public string ApplicantAddress { get; set; }
        public string CustodialName { get; set; }
        public string CustodialPhone { get; set; }
        public string CustodialSocialStatus { get; set; }
        public string CustodialAddress { get; set; }
        public Nullable<int> ChildrenNumberMale { get; set; }
        public Nullable<int> ChildrenNumberFemale { get; set; }
        public string CaseType { get; set; }
        public Nullable<double> ViewingHours { get; set; }
        public string ViewingPlace { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual Users_Table Users_Table { get; set; }
    }
}
