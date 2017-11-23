using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Beneficiaries
{
    public class BeneficiariesViewModel
    {

      
        public int Beneficiaries_ID
        {
            get;
            set;
        }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "من فضلك أدخل رقم صحيح ")]
        [Required]
        [DisplayName("رقم الهوية:")]

        public string BeneficiariesIDNumber
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم المستفيد:")]
        public string BeneficiariesName
        {
            get;
            set;
        }

        [RegularExpression("^[0-9]*$", ErrorMessage = "من فضلك أدخل رقم صحيح ")]
        [DisplayName("هاتف:")]
        public string BeneficiariesPhone
        {
            get;
            set;
        }


        [UIHint("GenderID")]
        [DisplayName("الجنس :")]
        public int? GenderID { get; set; }
    }
}