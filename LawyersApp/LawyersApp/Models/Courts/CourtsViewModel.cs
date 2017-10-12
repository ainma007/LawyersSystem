using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace LawyersApp.Models.Courts
{
    public class CourtsViewModel
    {
        [ScaffoldColumn(false)]
        public int CourtsID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم المحكمة:")]
        public string CourtsName
        {
            get;
            set;
        }
    }
}