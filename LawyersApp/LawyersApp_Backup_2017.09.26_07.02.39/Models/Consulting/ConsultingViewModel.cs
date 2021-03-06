﻿using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.Consulting
{
    public class ConsultingViewModel
    {

        [ScaffoldColumn(false)]
        public int ConsultingID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل الرقم .")]

        [DisplayName("رقم المركز:")]
        public string ConsultingNumber
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]

        [DisplayName("تاريخ الورد:")]
        [DataType(DataType.Date)]
        public DateTime ConsultingDate
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل اسم المستشير .")]

        [DisplayName("اسم المستشير:")]
        public string ConsultantName
        {
            get;
            set;
        }

        [DisplayName("الاستشارة المطلوبة:")]
        [AllowHtml]
        public string CounselingRequired
        {
            get;
            set;
        }

        [DisplayName("الاستشارة المقدمة:")]
        [AllowHtml]
        public string CounselingRendered
        {
            get;
            set;
        }

        [DisplayName("مقدم الاستشارة:")]


        public string ConsultingProvider
        {
            get;
            set;
        }

        [DisplayName("مآل الاستشارة:")]
      

        public string CounselingStatus
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