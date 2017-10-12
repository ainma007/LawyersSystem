using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace LawyersApp.Models.SystemicIssues
{
    public class SystemicIssuesViewModel
    {
        [ScaffoldColumn(false)]
        public int SystemicIssuesID
        {
            get;
            set;
        }

     
        [Required(ErrorMessage = "من فضلك ادخل رقم المحكمة .")]

        [DisplayName("رقم المحكمة:")]
        public string CourtsNumber
        {
            get;
            set;
        }


        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الورود:")]
        [DataType(DataType.Date)]
        public DateTime DateOfCase
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الايداع:")]
        [DataType(DataType.Date)]
        public DateTime DepositDate
        {
            get;
            set;
        }

        [DisplayName("اسم  الموكل:")]
        public string ClientName
        {
            get;
            set;
        }

        [DisplayName("رقم هوية  الموكل:")]
        public string ClientIDNumber
        {
            get;
            set;
        }


        [DisplayName("رقم هاتف الموكل:")]
        public string ClientPhone
        {
            get;
            set;
        }

        [DisplayName("عنوان الموكل:")]
        public string ClientAddress
        {
            get;
            set;
        }



        [DisplayName("اسم  الخصم:")]
        public string AdversaryName
        {
            get;
            set;
        }
        [DisplayName("الجنس:")]
        public string ClientGendr
        {
            get;
            set;
        }

        

        [DisplayName("رقم هوية  الخصم:")]
        public string AdversaryIDNumber
        {
            get;
            set;
        }


        [DisplayName("رقم هاتف الخصم:")]
        public string AdversaryPhone
        {
            get;
            set;
        }

        [DisplayName("عنوان الخصم:")]
        public string AdversaryAddress
        {
            get;
            set;
        }


        [UIHint("ClientTypeOfCase")]
        public TypeOfCaseForeignkey TypeOfCase
        {
            get;
            set;
        }
        [Required(ErrorMessage = "من فضلك اختر نوع القضية ")]

        [UIHint("TypeOfCaseID")]
        [DisplayName("نوع القضية :")]
        public int? TypeOfCaseID { get; set; }


        [UIHint("ClientCourts")]
        public CourtsForeignkey Courts
        {
            get;
            set;
        }
        [Required(ErrorMessage = "من فضلك اختر المحكمة ")]

        [UIHint("CourtsID")]
        [DisplayName("اسم المحكمة :")]
        public int? CourtsID { get; set; }


        [UIHint("ClientLawyer")]
        public LawyerForeignkey Lawyer
        {
            get;
            set;
        }
        [Required(ErrorMessage = "من فضلك اختر المحامي ")]

        [UIHint("LawyerID")]
        [DisplayName("اسم المحامي :")]
        public int? LawyerID { get; set; }


        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ اغلاق الملف:")]
        [DataType(DataType.Date)]
        public DateTime DateOfClosure
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