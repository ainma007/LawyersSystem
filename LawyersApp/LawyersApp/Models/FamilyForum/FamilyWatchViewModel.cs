using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.FamilyForum
{
    public class FamilyWatchViewModel
    {
        public int FamilyWatchID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الزيارة:")]
        [DataType(DataType.Date)]
        public DateTime Date
        {
            get;
            set;
        }

        [DisplayName(" من:")]
        [DataType(DataType.Time)]
        public DateTime timeFrom
        {
            get;
            set;
        }

        [DisplayName(" الى:")]
        [DataType(DataType.Time)]
        public DateTime TimeTo
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل اسم طالب الحضور .")]

        [DisplayName("الحضور من طرف طالب المشاهدة :")]
        public string Attendees
        {
            get;
            set;
        }

        [DisplayName("  الحضور:")]
        [DataType(DataType.Time)]
        public DateTime HoursAttendance
        {
            get;
            set;
        }

        [DisplayName("  الانصراف:")]
        [DataType(DataType.Time)]
        public DateTime hourDeparture
        {
            get;
            set;
        }
        [Required(ErrorMessage = "من فضلك ادخل اسم طالب الحضور .")]
        [DisplayName("الحضور من طرف الحاضن:")]
        public string CustodialAttendees
        {
            get;
            set;
        }

        [DisplayName(" الحضور:")]
        [DataType(DataType.Time)]
        public DateTime CustodialHoursAttendance
        {
            get;
            set;
        }

        [DisplayName(" الانصراف:")]
        [DataType(DataType.Time)]
        public DateTime CustodialhourDeparture
        {
            get;
            set;
        }

        [DisplayName("الأخصائي المسؤول :")]
        public string Specialist
        {
            get;
            set;
        }

        [DisplayName("ملاحظات :")]
        public string Notes
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
        public int? FamilyForumID { get; set; }


    }
}