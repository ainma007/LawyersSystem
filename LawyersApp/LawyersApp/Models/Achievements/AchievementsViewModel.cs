using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.Achievements
{
    public class AchievementsViewModel
    {
        [ScaffoldColumn(false)]
        public int AchievementID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك اسم الانجاز .")]

        [DisplayName("اسم الانجاز:")]
        public string AchievementsName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]

        [DisplayName("تاريخ الانجاز:")]
        [DataType(DataType.Date)]
        public DateTime AchievementsDate
        {
            get;
            set;
        }


        [DisplayName("ملخص الانجاز:")]
        [AllowHtml]
        public string AchievementsAbstract
        {
            get;
            set;
        }

        [DisplayName("رابط المرفقات:")]
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