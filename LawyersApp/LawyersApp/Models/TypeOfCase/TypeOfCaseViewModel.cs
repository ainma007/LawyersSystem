using LawyersApp.Models.Foreignkey;
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


        [UIHint("ClientIssuesType")]
        public IssuesTypeForeingKey IssuesType
        {
            get;
            set;
        }
        [Required(ErrorMessage = "من النوعية ")]

        [UIHint("IssuesTypeID")]
        [DisplayName("النوعية :")]
        public int? IssuesTypeID { get; set; }
      

    }
}