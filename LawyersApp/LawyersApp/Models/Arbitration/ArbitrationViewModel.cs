using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LawyersApp.Models.Arbitration
{
    public class ArbitrationViewModel
    {
      
        public int ArbitrationID
        {
            get;
            set;
        }

       




        [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
        [DisplayName("تاريخ الورود:")]
        [DataType(DataType.Date)]
        public DateTime ArbitrationDate
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


        [DisplayName("الحالة الاجتماعية للطرف الأول:")]
        public string FirstSocialstatus
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
      

       


        [DisplayName("اسم الطرف الثاني:")]
        public string SecondSideName
        {
            get;
            set;
        }

        [DisplayName("رقم هوية  الطرف الثاني:")]
        public string SecondSideIDNumber
        {
            get;
            set;
        }


        [DisplayName("رقم هاتف الطرف الثاني:")]
        public string SecondSidePhone
        {
            get;
            set;
        }

        [DisplayName("الحالة الاجتماعية للطرف الثاني:")]
        public string SecondSocialstatus
        {
            get;
            set;
        }
        [DisplayName("عنوان الطرف الثاني:")]
        public string SecondSideAddress
        {
            get;
            set;
        }

        [DisplayName("اسم الوسيط:")]
        public string ArbitrationName
        {
            get;
            set;
        }


        [DisplayName("رقم هاتف الوسيط:")]
        public string ArbitrationPhone
        {
            get;
            set;
        }


        [DisplayName("قرار التحكيم :")]
        [AllowHtml]
        public string ArbitrationDecision
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
        public int? ProjectID { get; set; }
    }
}