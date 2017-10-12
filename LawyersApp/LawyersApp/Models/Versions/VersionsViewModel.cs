using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.Versions
{
    public class VersionsViewModel
    {

        [ScaffoldColumn(false)]
        public int VersionsID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل الاسم .")]

        [DisplayName("اسم الاصدار او المطبوعة :")]
        public string VersionsName
        {
            get;
            set;
        }



        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الاصدار:")]
        [DataType(DataType.Date)]
        public DateTime VersionsDate
        {
            get;
            set;
        }

        [DisplayName("اسم الشريك :")]
        public string PartnerName
        {
            get;
            set;
        }

        [DisplayName("عدد الاصدارات :")]
        [AllowHtml]
        public int? VersionsNumbers
        {
            get;
            set;
        }

        [DisplayName("اعداد النسخ:")]
        [AllowHtml]
        public int? TypesOfCopies
        {
            get;
            set;
        }


        [DisplayName("رابط الكتروني :")]
        public string url
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