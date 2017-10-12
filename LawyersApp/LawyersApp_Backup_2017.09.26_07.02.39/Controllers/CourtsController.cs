using LawyersApp.Models.Courts;
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
    public class CourtsController : Controller
    {
        // GET: Courts
        public ActionResult Courts()
        {
            return View();
        }

        private CourtsService CourtsService;
        public CourtsController()
        {
            CourtsService = new CourtsService(new LawyersEntities());
        }
        public ActionResult Courts_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(CourtsService.Read().ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Courts_Create([DataSourceRequest] DataSourceRequest request, CourtsViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                CourtsService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Courts_Update([DataSourceRequest] DataSourceRequest request, CourtsViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                CourtsService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Courts_Destroy([DataSourceRequest] DataSourceRequest request, CourtsViewModel db)
        {
            if (db != null)
            {
                CourtsService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }

    }
}