using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.AwarenessWorkshops
{
    public class AwarenessWorkshopsViewModel
    {
        [ScaffoldColumn(false)]
        public int AwarenessID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل الرقم .")]

        [DisplayName("اسم الورشة :")]
        public string AwarenessName
        {
            get;
            set;
        }



        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الورشة:")]
        [DataType(DataType.Date)]
        public DateTime AwarenessDate
        {
            get;
            set;
        }

        [DisplayName("عدد ساعات الورشة:")]
        [AllowHtml]
        public int? TotalHours
        {
            get;
            set;
        }

        [DisplayName("اعداد المستفدين:")]
        [AllowHtml]
        public int? TotalBeneficiaries
        {
            get;
            set;
        }
        [DisplayName("عدد الذكور:")]
        [AllowHtml]
        public int? Males
        {
            get;
            set;
        }

        [DisplayName("عدد الاناث:")]
        [AllowHtml]
        public int? Females
        {
            get;
            set;
        }
        [DisplayName("عدد الأولاد:")]
        [AllowHtml]
        public int? Boy
        {
            get;
            set;
        }
        [DisplayName("عدد البنات:")]
        [AllowHtml]
        public int? Girl
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