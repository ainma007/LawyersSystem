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

        [DisplayName("اسم الدورة :")]
        public string CoursesName
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
        [DisplayName("عدد ساعات التدريب:")]
        [AllowHtml]
        public int? TrainingHours
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


        [UIHint("ClientUsers")]
        public UsersForeignkey Users
        {
            get;
            set;
        }

        [UIHint("UserID")]
        [DisplayName("مدخل البيانات :")]
        public int? UserID { get; set; }

        [UIHint("ClientTargetGroup")]
        public TargetGroupFroingKey TargetGroup
        {
            get;
            set;
        }

        [UIHint("TargetGroupID")]
        [DisplayName("الفئة المستهدفة :")]
        public int? TargetGroupID { get; set; }
        public int? ProjectID { get; set; }

    }
}