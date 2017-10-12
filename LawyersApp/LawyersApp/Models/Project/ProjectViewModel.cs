using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Project
{
    public class ProjectViewModel
    {

        [ScaffoldColumn(false)]
        public int ProjectID
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


        [DisplayName("الحالة:")]
        public Nullable<bool> Status
        {
            get;
            set;
        }


    }
}