using LawyersApp.Models.Lawyer;
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
    public class LawyerController : Controller
    {
        // GET: Lawyer
        public ActionResult Lawyer()
        {
            return View();
        }
        private LawyerService LawyerService;
        public LawyerController()
        {
            LawyerService = new LawyerService(new LawyersEntities());
        }
        public ActionResult Lawyer_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(LawyerService.Read().ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Lawyer_Create([DataSourceRequest] DataSourceRequest request, LawyerViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                LawyerService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Lawyer_Update([DataSourceRequest] DataSourceRequest request, LawyerViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                LawyerService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Lawyer_Destroy([DataSourceRequest] DataSourceRequest request, LawyerViewModel db)
        {
            if (db != null)
            {
                LawyerService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }

    }
}