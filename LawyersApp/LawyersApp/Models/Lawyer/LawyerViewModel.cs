using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace LawyersApp.Models.Lawyer
{
    public class LawyerViewModel
    {
        [ScaffoldColumn(false)]
        public int LawyerID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم  المحامي:")]
        public string LawyerName
        {
            get;
            set;
        }

        [DisplayName("رقم  الهاتف:")]
        public string LawyerPhone
        {
            get;
            set;
        }

        [DisplayName("العنوان:")]
        public string LawyerAddress
        {
            get;
            set;
        }
    }
}