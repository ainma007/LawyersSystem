using LawyersApp.Models.Courts;
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
    public class CourtsController : Controller
    {
        // GET: Courts
        [SessionTimeout]
        [HttpGet]
        public ActionResult Courts()
        {
            PopulateIssuesType();
            return View();
        }

        private CourtsService CourtsService;
        public CourtsController()
        {
            CourtsService = new CourtsService(new LawyersEntities());
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
            try
            {
                if (ModelState.IsValid)
                {
                    if (db != null)
                    {
                        CourtsService.Destroy(db);
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
            return Json(CourtsService.GetIssuesType(), JsonRequestBehavior.AllowGet);
        }


    }
}