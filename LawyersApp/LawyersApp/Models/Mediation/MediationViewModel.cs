using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.Mediation
{
    public class MediationViewModel
    {
        [ScaffoldColumn(false)]
        public int MediationID
        {
            get;
            set;
        }

      
       


        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الورود:")]
        [DataType(DataType.Date)]
        public DateTime MediationDate
        {
            get;
            set;
        }

    

        [DisplayName("اسم  الطرف الأول:")]
        public string FirstSideName
        {
            get;
            set;
        }
        [DisplayName("الجنس:")]
        public string FirstSideGender
        {
            get;
            set;
        }

        [DisplayName("العمر:")]
        public int? FirstSideAge
        {
            get;
            set;
        }

        [DisplayName("رقم هوية  الطرف الأول:")]
        public string FirstSideIDNumber
        {
            get;
            set;
        }


        [DisplayName("رقم هاتف الطرف الأول:")]
        public string FirstSidePhone
        {
            get;
            set;
        }
        [DisplayName("الحالة الاجتماعية للطرف الأول:")]
        public string FirstSocialstatus
        {
            get;
            set;
        }


        [DisplayName("عنوان الطرف الأول:")]
        public string FirstSideAddress
        {
            get;
            set;
        }



        [DisplayName("اسم الطرف الثاني:")]
        public string SecondSideName
        {
            get;
            set;
        }

        [DisplayName("رقم هوية  الطرف الثاني:")]
        public string SecondSideIDNumber
        {
            get;
            set;
        }


        [DisplayName("رقم هاتف الطرف الثاني:")]
        public string SecondSidePhone
        {
            get;
            set;
        }

        [DisplayName("الحالة الاجتماعية للطرف الثاني:")]
        public string SecondSocialstatus
        {
            get;
            set;
        }
        [DisplayName("عنوان الطرف الثاني:")]
        public string SecondSideAddress
        {
            get;
            set;
        }

        [DisplayName("اسم الوسيط:")]
        public string MediatorName
        {
            get;
            set;
        }


        [DisplayName("رقم هاتف الوسيط:")]
        public string MediatorPhone
        {
            get;
            set;
        }


        [DisplayName("القرار :")]
        [AllowHtml]
        public string Agreement
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

        [UIHint("ClientIssuesType")]
        public IssuesTypeForeingKey IssuesType
        {
            get;
            set;
        }
        [Required(ErrorMessage = "من فضلك اختر النوعية ")]

        [UIHint("IssuesTypeID")]
        [DisplayName("النوعية :")]
        public int? IssuesTypeID { get; set; }

        [UIHint("ClientDiligenceType")]
        public DiligenceTypeForeingKey DiligenceType
        {
            get;
            set;
        }
        [Required(ErrorMessage = "من فضلك اختر نوع الجهد ")]

        [UIHint("IssuesTypeID")]
        [DisplayName("نوع الجهد :")]
        public int? DiligenceTypeID { get; set; }

        public int? ProjectID { get; set; }
    }
}