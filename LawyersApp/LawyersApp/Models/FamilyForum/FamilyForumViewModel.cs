using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.FamilyForum
{
    public class FamilyForumViewModel
    {

        [ScaffoldColumn(false)]
        public int FamilyForumID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الزيارة:")]
        [DataType(DataType.Date)]
        public DateTime ViewingDate
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل اسم طالب المشاهدة .")]

        [DisplayName("اسم طالب المشاهدة :")]
        public string ApplicantName
        {
            get;
            set;
        }

        [DisplayName("رقم الهاتف :")]
        public string ApplicantPhone
        {
            get;
            set;
        }

        [DisplayName("الحالة الإجتماعية :")]
        public string ApplicantSocialStatus
        {
            get;
            set;
        }

        [DisplayName("مكان السكن :")]
        public string ApplicantAddress
        {
            get;
            set;
        }

        [DisplayName("اسم الحاضن :")]
        public string CustodialName
        {
            get;
            set;
        }

        [DisplayName("رقم هاتف الحاضن :")]
        public string CustodialPhone
        {
            get;
            set;
        }


        [DisplayName("الحالة الإجتماعية :")]
        public string CustodialSocialStatus
        {
            get;
            set;
        }


        [DisplayName("مكان السكن :")]
        public string CustodialAddress
        {
            get;
            set;
        }

       

       
        [DisplayName("عدد الأطفال الذكور:")]
        [AllowHtml]
        public int? ChildrenNumberMale
        {
            get;
            set;
        }

        [DisplayName("عدد الأطفال الاناث:")]
        [AllowHtml]
        public int? ChildrenNumberFemale
        {
            get;
            set;
        }


        [DisplayName("نوع القضية :")]
        public string CaseType
        {
            get;
            set;
        }

        [DisplayName("عدد ساعات المشاهدة:")]
        [AllowHtml]
        public double? ViewingHours
        {
            get;
            set;
        }

        [DisplayName("مكان المشاهدة :")]
        public string ViewingPlace
        {
            get;
            set;
        }

        [UIHint("ClientUsers")]
        public UsersForeignkey Users
        {
            get;
            set;
        }

        [UIHint("UserID")]
        [DisplayName("مدخل البيانات :")]
        public int? UserID { get; set; }

        public int? ProjectID { get; set; }
    }
}