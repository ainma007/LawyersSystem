using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.LegalIssues
{
    public class LegalSessionViewModel
    {


        [ScaffoldColumn(false)]
        public int SessionsID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل الرقم .")]

        [DisplayName("رقم الجلسة:")]
        public string SessionsNumber
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الجلسة:")]
        [DataType(DataType.Date)]
        public DateTime SessionsDate
        {
            get;
            set;
        }


        [DisplayName(" القرار:")]
        public string Sessions_Decision
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

        public int? LegalIssuesID { get; set; }

    }
}