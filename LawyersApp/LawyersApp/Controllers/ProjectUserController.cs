using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Foreignkey;
using LawyersApp.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Controllers
{
    public class ProjectUserController : Controller
    {
        // GET: ProjectUser
        public ActionResult ProjectUser()
        {
            PopulateProject();
            PopulateUsers();
            return View();
        }

        private ProjectControlSerivce ProjectControlSerivce;
        public ProjectUserController()
        {
            ProjectControlSerivce = new ProjectControlSerivce(new LawyersEntities());
        }
        public void PopulateProject()
        {
            var dataContext = new LawyersEntities();
            var Project = dataContext.Project_Table

                              .Select(c => new ProjectForeignkey
                              {
                                  ProjectID = c.ProjectID,
                                  ProjectName = c.ProjectName
                              })
                              .OrderBy(e => e.ProjectID);

            ViewData["Project"] = Project;
            ViewData["defaultProject"] = Project.First();
        }
        public void PopulateUsers()
        {
            //  وهنا كمان لازم يكون نشيط حتى يتم ادراجه في المشاريع
            var dataContext = new LawyersEntities();
            var users = dataContext.Users_Table

                              .Select(c => new UsersForeignkey
                              {
                                  UserID = c.UserID,
                                  FullName = c.FullName
                              })
                              .OrderBy(e => e.UserID);

            ViewData["users"] = users;
            ViewData["defaultUser"] = users.First();
        }
        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ProjectControlSerivce.Read().ToDataSourceResult(request));
        }

        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, ProjectControlViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ProjectControlSerivce.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, ProjectControlViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ProjectControlSerivce.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, ProjectControlViewModel db)
        {
            if (db != null)
            {
                ProjectControlSerivce.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        public JsonResult GetProject()
        {
            return Json(ProjectControlSerivce.GetProject(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUsers()
        {
            return Json(ProjectControlSerivce.GetUsers(), JsonRequestBehavior.AllowGet);
        }
    }
}