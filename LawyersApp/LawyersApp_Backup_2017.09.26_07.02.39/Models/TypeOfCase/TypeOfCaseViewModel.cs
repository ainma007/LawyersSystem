using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.TypeOfCase
{
    public class TypeOfCaseViewModel
    {


        [ScaffoldColumn(false)]
        public int TypeOfCaseID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("نوع القضية:")]
        public string TypeOfCase
        {
            get;
            set;
        }
    }
}