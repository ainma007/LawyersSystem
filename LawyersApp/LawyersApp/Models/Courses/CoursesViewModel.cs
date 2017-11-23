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

       
        public int CoursesID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل اسم الدورة .")]

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

        [RegularExpression("^[0-9]*$", ErrorMessage = "من فضلك أدخل رقم صحيح ")]
        [Required(ErrorMessage = "من فضلك رقم .")]
        [DisplayName("عدد الجلسات :")]
        public int? TotalSessions
        {
            get;
            set;
        }
        [RegularExpression("^[0-9]*$", ErrorMessage = "من فضلك أدخل رقم صحيح ")]
        [Required(ErrorMessage = "من فضلك رقم .")]

        [DisplayName("عدد ساعات التدريب:")]
      
        public int? TrainingHours
        {
            get;
            set;
        }
       
        [DisplayName("اعداد المستفدين:")]
         public int? TotalBeneficiaries
        {
            get;
            set;
        }
        [RegularExpression("^[0-9]*$", ErrorMessage = "من فضلك أدخل رقم صحيح ")]
        [Required(ErrorMessage = "من فضلك رقم .")]

        [DisplayName("عدد الذكور:")]
       
        public int? Males
        {
            get;
            set;
        }
        [RegularExpression("^[0-9]*$", ErrorMessage = "من فضلك أدخل رقم صحيح ")]
        [Required(ErrorMessage = "من فضلك رقم .")]

        [DisplayName("عدد الاناث:")]
      
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