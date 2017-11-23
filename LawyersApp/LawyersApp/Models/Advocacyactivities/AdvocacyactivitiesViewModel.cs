using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.Advocacyactivities
{
    public class AdvocacyactivitiesViewModel
    {
       
          
            public int AdvocacyactivitiesID
        {
                get;
                set;
            }

            [Required(ErrorMessage = "من فضلك ادخل الاسم .")]

            [DisplayName("اسم النشاط :")]
            public string Name
        {
                get;
                set;
            }



            [Required(ErrorMessage = "من فضلك ادخل التاريخ بشكل صحيح .")]
            [DisplayName("تاريخ النشاط:")]
            [DataType(DataType.Date)]
            public DateTime AdvocacyDate
        {
                get;
                set;
            }

        [DisplayName("الجهة المنفذة :")]
        public string executingagency
        {
            get;
            set;
        }

        [DisplayName("الجهة المستفيدة :")]
        public string beneficiary
        {
            get;
            set;
        }


        [DisplayName("المنطقة الجغرافية :")]
        public string GeographicArea
        {
            get;
            set;
        }

        [DisplayName("رابط الكتروني :")]
        public string url
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
