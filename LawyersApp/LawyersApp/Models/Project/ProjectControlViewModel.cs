using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Project
{
    public class ProjectControlViewModel
    {

        [ScaffoldColumn(false)]
        public int ProjectControlID
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
        [Required(ErrorMessage = "من فضلك اختر المستخدم .")]

        [DisplayName("المستخدم :")]

        public int? UserID { get; set; }

        [UIHint("ClientProject")]
        public ProjectForeignkey Project
        {
            get;
            set;
        }
        
        [Required(ErrorMessage = "من فضلك اختر المشروع .")]
        [UIHint("ProjectID")]
        [DisplayName("المشروع:")]
        public int? ProjectID { get; set; }

      
        [DisplayName("الحالة:")]
        public Nullable<bool> Status
        {
            get;
            set;
        }
    }
   
}