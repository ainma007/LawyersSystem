using LawyersApp.Models.TypeOfCase;
using LawyersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace LawyersApp.Controllers
{
    public class TypeOfCaseController : Controller
    {
        // GET: TypeOfCase
        public ActionResult TypeOfCases()
        {
            return View();
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
            if (db != null)
            {
                TypeOfCaseService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }

    }
}