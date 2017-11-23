using LawyersApp.Models.TypeOfCase;
using LawyersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LawyersApp.Models.Foreignkey;
using LawyersApp.Models.Attributes;

namespace LawyersApp.Controllers
{
    public class TypeOfCaseController : Controller
    {
        // GET: TypeOfCase
        [SessionTimeout]
        [HttpGet]
        public ActionResult TypeOfCases()
        {
            PopulateIssuesType();
            return View();
        }

        private void PopulateIssuesType()
        {
            var dataContext = new LawyersEntities();
            var IssuesType = dataContext.IssuesType_Table
                        .Select(c => new IssuesTypeForeingKey
                        {
                            IssuesTypeID = c.IssuesTypeID,
                            IssuesTypename = c.IssuesTypename
                        })
                        .OrderBy(e => e.IssuesTypeID);

            ViewData["IssuesType"] = IssuesType;
            ViewData["defaultIssuesType"] = IssuesType.First();
        }


        private TypeOfCaseService TypeOfCaseService;
        public TypeOfCaseController()
        {
            TypeOfCaseService = new TypeOfCaseService(new LawyersEntities());
        }
        public ActionResult TypeOfCases_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(TypeOfCaseService.Read().ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult TypeOfCases_Create([DataSourceRequest] DataSourceRequest request, TypeOfCaseViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                TypeOfCaseService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult TypeOfCases_Update([DataSourceRequest] DataSourceRequest request, TypeOfCaseViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                TypeOfCaseService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult TypeOfCases_Destroy([DataSourceRequest] DataSourceRequest request, TypeOfCaseViewModel db)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db != null)
                    {
                        TypeOfCaseService.Destroy(db);
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("خطأ", "لا يمكن الحذف");
                return Json(new[] { db }.ToDataSourceResult(request, ModelState));

            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult GetIssuesType()
        {
            return Json(TypeOfCaseService.GetIssuesType(), JsonRequestBehavior.AllowGet);
        }

    }
}