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
using LawyersApp.Models.Attributes;

namespace LawyersApp.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses

        [SessionTimeout]
        [HttpGet]
        public ActionResult Courses(string projectid)
        {
           
            Session["Projectid"] = int.Parse(projectid.ToString());
            int proid = int.Parse(Session["Projectid"].ToString());
           
            int UserID = int.Parse(Session["UserID"].ToString());
        
            #region(تأكيد اذا كان المستخدم تابع لمشروع)
            if ((string)Session["UserType"] != "1")
            {
                try
                {
                    using (LawyersEntities dc = new LawyersEntities())
                    {
                        // Check If Existed Or Not : 
                        var u = dc.ProjectControl_Table.Single(i => i.UserID == UserID
                                                                    && i.ProjectID == proid &&
                                                                    i.Status == true);
                        if (u != null)
                        {
                            ViewBag.CurrentUser = true;
                        }

                    }
                }
                catch (Exception)
                {

                    ViewBag.CurrentUser = false;

                }

            }
            #endregion
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
        public ActionResult Paging_Orders([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }

        private static IEnumerable<CoursesViewModel> GetOrders()
        {
            var entities = new LawyersEntities();
            return entities.Courses_Table
              .Select(db => new CoursesViewModel
              {
                  CoursesID = db.CoursesID,
                  CoursesName = db.CoursesName,
                  CoursesStartDate = db.CoursesStartDate.HasValue ? db.CoursesStartDate.Value : default(DateTime),
                  CoursesEndDate = db.CoursesEndDate.HasValue ? db.CoursesEndDate.Value : default(DateTime),
                  TotalSessions = db.TotalSessions,
                  TrainingHours = db.TrainingHours,
                  TotalBeneficiaries = db.TotalBeneficiaries,
                  Males = db.Males,
                  Females = db.Females,
                  UserID = db.UserID,

                  Users = new UsersForeignkey()
                  {
                      UserID = db.Users_Table.UserID,
                      FullName = db.Users_Table.FullName,
                  },
                  TargetGroupID = db.TargetGroupID,

                  TargetGroup = new TargetGroupFroingKey()
                  {
                      TargetGroupID = db.TargetGroup_Table.TargetGroupID,
                      TargetGroupName = db.TargetGroup_Table.TargetGroupName,
                  },

                  ProjectID = db.ProjectID,

              });
        }

        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
            if ((string)Session["UserType"] == "3")
            {
                return Json(CoursesService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
            else
            {
                return Json(CoursesService.Read().Where(u => u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
        }
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