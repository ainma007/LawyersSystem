using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Users
{
    public class UserViewModel
    {

        [ScaffoldColumn(false)]
        public int UserID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم الموظف:")]
        public string FullName
        {
            get;
            set;
        }


        [DisplayName("اسم المستخدم:")]
        public string Username
        {
            get;
            set;
        }


        [DisplayName("الباسورد:")]
        public string Password
        {
            get;
            set;
        }


        [DisplayName("نوع المستخدم:")]
        [UIHint("UserType")]
        public string UserType
        {
            get;
            set;
        }


        [DisplayName("الحالة:")]
        public Nullable<bool> userstatus
        {
            get;
            set;
        }
    }
}