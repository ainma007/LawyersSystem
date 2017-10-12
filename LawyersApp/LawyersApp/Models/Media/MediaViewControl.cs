using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.Media
{
    public class MediaViewControl
    {
        [ScaffoldColumn(false)]
        public int MediaID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل اسم الاعلام .")]

        [DisplayName("الاسم :")]
        public string MediaName
        {
            get;
            set;
        }



        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("التاريخ :")]
        [DataType(DataType.Date)]
        public DateTime MediaDate
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
        public int? MediaNumber
        {
            get;
            set;
        }

        [DisplayName("اعداد الدقائق:")]
        public int? minutes
        {
            get;
            set;
        }

        [DisplayName("رابط الكتروني :")]
        [AllowHtml]
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

        [UIHint("ClientMediaType")]
        public MediaTypeForingKey MediaType
        {
            get;
            set;
        }

        [UIHint("MediaTypeID")]
        [DisplayName("نوع الاعلام :")]
        public int? MediaTypeID { get; set; }
        public int? ProjectID { get; set; }


    }
}