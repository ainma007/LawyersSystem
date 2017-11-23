using LawyersApp.Models.Foreignkey;
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

       
        public int ConsultingID
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

        [Required(ErrorMessage = "من فضلك اختر المستفيد")]

  


        [DisplayName("رقم الهوية :")]
        public string BeneficiariesIDNumber { get; set; }

        [Required(ErrorMessage = "من فضلك اختر المستفيد")]

        [UIHint("Beneficiaries_ID")]
        [DisplayName("رقم الهوية :")]
        public int? Beneficiaries_ID { get; set; }

        [DisplayName("اسم المستفيد:")]
        public string BeneficiariesName
        {
            get;
            set;
        }

        [DisplayName("الجنس:")]
        public string Gender
        {
            get;
            set;
        }
        [UIHint("ClientBeneficiaries")]
        public BeneficiariesForeignkey Beneficiaries
        {
            get;
            set;
        }

        [Required(ErrorMessage = "من فضلك ادخل العمر .")]
        [DisplayName("العمر:")]
        public int? BeneficiariesAge
        {
            get;
            set;
        }




        [Required(ErrorMessage = "من فضلك اختر المحافظة")]

        [UIHint("Governorate_ID")]
        [DisplayName("المحافظة :")]
        public int? Governorate_ID { get; set; }


        [UIHint("ClientGovernorate")]
        public GovernorateForeignkey Governorate
        {
            get;
            set;
        }



        [Required(ErrorMessage = "من فضلك اختر المنطقة")]

        [UIHint("Area_ID")]
        [DisplayName("المنطقة :")]
        public int? Area_ID { get; set; }


        [UIHint("ClientArea")]
        public AreaForeignkey Area
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

    
        [DisplayName("مآل الاستشارة:")]
      

        public string CounselingStatus
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

        [UIHint("IssuesTypeID")]
        [DisplayName("النوعية :")]
        public int? IssuesTypeID { get; set; }

        [UIHint("ClientTypeOfCase")]
        public TypeOfCaseForeignkey TypeOfCase
        {
            get;
            set;
        }

        [UIHint("TypeOfCaseID")]
        [DisplayName("نوع القضية :")]
        public int? TypeOfCaseID { get; set; }

       

        [UIHint("ClientUsers")]
        public UsersForeignkey Users
        {
            get;
            set;
        }

        [UIHint("UserID")]
        [DisplayName("مدخل البيانات :")]
        public int? UserID { get; set; }
        public int? ProjectID { get; set; }
    }
}