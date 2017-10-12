using LawyersApp.Models.Courses;
using LawyersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LawyersApp.Models.Foreignkey;


namespace LawyersApp.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Courses( string projectid)
        {
            Session["Projectid"] = int.Parse(projectid.ToString());
            PopulateTargetGroup();
            PopulateUsers(); 
            return View();
        }

        private CoursesService CoursesService;
        public CoursesController()
        {
            CoursesService = new CoursesService(new LawyersEntities());
        }

        public void PopulateTargetGroup()
        {
            var dataContext = new LawyersEntities();
            var TargetGroup = dataContext.TargetGroup_Table

                              .Select(c => new TargetGroupFroingKey
                              {
                                  TargetGroupID = c.TargetGroupID,
                                  TargetGroupName = c.TargetGroupName
                              })
                              .OrderBy(e => e.TargetGroupID);

            ViewData["TargetGroup"] = TargetGroup;
            ViewData["defaultTargetGroup"] = TargetGroup.First();
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
            return Json(CoursesService.Read().Where(u=> u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }
        public ActionResult Userdb_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(CoursesService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString())&& u.ProjectID==int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, CoursesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                CoursesService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, CoursesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                CoursesService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, CoursesViewModel db)
        {
            if (db != null)
            {
                CoursesService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        public JsonResult GetTargetGroup()
        {
            return Json(CoursesService.GetTargetGroup(), JsonRequestBehavior.AllowGet);
        }
    }
}