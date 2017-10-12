using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LawyersApp.Models.Arbitration
{
    public class ArbitrationViewModel
    {
        [ScaffoldColumn(false)]
        public int ArbitrationID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل الرقم .")]

        [DisplayName("رقم المركز:")]
        public string ArbitrationNumber
        {
            get;
            set;
        }




        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الورود:")]
        [DataType(DataType.Date)]
        public DateTime ArbitrationDate
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
        public string ArbitrationName
        {
            get;
            set;
        }


        [DisplayName("رقم هاتف الوسيط:")]
        public string ArbitrationPhone
        {
            get;
            set;
        }


        [DisplayName("قرار التحكيم :")]
        [AllowHtml]
        public string ArbitrationDecision
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