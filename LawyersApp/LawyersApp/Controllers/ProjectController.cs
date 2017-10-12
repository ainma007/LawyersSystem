using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Projects()
        {
            return View();
        }
        private ProjectService ProjectService;
        public ProjectController()
        {

            ProjectService = new ProjectService(new LawyersEntities());


        }


        public ActionResult Project_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ProjectService.Read().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Project_Create([DataSourceRequest] DataSourceRequest request, ProjectViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ProjectService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Project_Update([DataSourceRequest] DataSourceRequest request, ProjectViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ProjectService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Project_Destroy([DataSourceRequest] DataSourceRequest request, ProjectViewModel db)
        {
            if (db != null)
            {
                ProjectService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }

    }
}