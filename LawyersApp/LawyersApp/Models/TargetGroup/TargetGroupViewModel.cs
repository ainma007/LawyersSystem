using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.TargetGroup
{
    public class TargetGroupViewModel
    {


        [ScaffoldColumn(false)]
        public int TargetGroupID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم الفئة المستهدفة:")]
        public string TargetGroupName
        {
            get;
            set;
        }


    }
}