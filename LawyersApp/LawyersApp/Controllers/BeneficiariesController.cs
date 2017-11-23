using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Attributes;
using LawyersApp.Models.Beneficiaries;
using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Controllers
{
    public class BeneficiariesController : Controller
    {
        // GET: Beneficiaries
        [SessionTimeout]
        [HttpGet]
        public ActionResult Beneficiaries()
        {
            PopulateGender();
            return View();
        }

        public void PopulateGender()
        {
            //  وهنا كمان لازم يكون نشيط حتى يتم ادراجه في المشاريع
            var dataContext = new LawyersEntities();
            var Gender = dataContext.Gender_Table

                              .Select(c => new GenderForeignkey
                              {
                                  GenderID = c.GenderID,
                                  GenderName = c.GenderName
                              })
                              .OrderBy(e => e.GenderID);

            ViewData["Gender"] = Gender;
            ViewData["defaultGender"] = Gender.First();
        }

        private BeneficiariesService BeneficiariesService;
        public BeneficiariesController()
        {
            BeneficiariesService = new BeneficiariesService(new LawyersEntities());
        }
        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
       
                return Json(BeneficiariesService.Read().ToDataSourceResult(request));

         
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, BeneficiariesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                BeneficiariesService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, BeneficiariesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                BeneficiariesService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, BeneficiariesViewModel db)
        {
            if (db != null)
            {
                BeneficiariesService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        public JsonResult GetGender()
        {
            return Json(BeneficiariesService.GetGender(), JsonRequestBehavior.AllowGet);
        }

       
    }
}