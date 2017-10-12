using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Project
{
    public class ProjectUserViewModel
    {
        [ScaffoldColumn(false)]
        public int ProjectControlID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل اسم المشروع")]

        [DisplayName("اسم المشروع:")]
        public string ProjectName
        {
            get;
            set;
        }


        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ البداية:")]
        [DataType(DataType.Date)]
        public DateTime StartData
        {
            get;
            set;
        }


        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الانتهاء:")]
        [DataType(DataType.Date)]
        public DateTime EndDate
        {
            get;
            set;
        }
        public int? ProjectID
        {
            get;
            set;
        }

        public int? UserID
        {
            get;
            set;
        }

        public Nullable<bool> Status
        {
            get;
            set;
        }
    }
}
