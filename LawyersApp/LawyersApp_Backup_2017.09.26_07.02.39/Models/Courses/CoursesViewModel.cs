using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.Courses
{
    public class CoursesViewModel
    {

        [ScaffoldColumn(false)]
        public int CoursesID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل الرقم .")]

        [DisplayName("رقم الدورة:")]
        public string CoursesNumber
        {
            get;
            set;
        }

        

        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ البداية:")]
        [DataType(DataType.Date)]
        public DateTime CoursesStartDate
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الانتهاء:")]
        [DataType(DataType.Date)]
        public DateTime CoursesEndDate
        {
            get;
            set;
        }
        [DisplayName("الاستشارة المقدمة:")]
        [AllowHtml]
        public string CoursesSummary
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
    }
}