using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Advocacyactivities;
using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawyersApp.Models.Attributes;

namespace LawyersApp.Controllers
{
    public class AdvocacyactivitiesController : Controller
    {
        [SessionTimeout]
        [HttpGet]

        // GET: Advocacyactivities
        public ActionResult Advocacy( string projectid)
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

            PopulateUsers();
            return View();
        }
        private AdvocacyactivitiesService AdvocacyactivitiesService;
        public AdvocacyactivitiesController()
        {
            AdvocacyactivitiesService = new AdvocacyactivitiesService(new LawyersEntities());
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
            if ((string)Session["UserType"] == "3")
            {
                return Json(AdvocacyactivitiesService.Read().Where(u => u.ProjectID == int.Parse(Session["Projectid"].ToString()) && u.UserID == int.Parse(Session["UserID"].ToString())).ToDataSourceResult(request));


            }
            else
            {
                return Json(AdvocacyactivitiesService.Read().Where(u => u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
        }
       
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, AdvocacyactivitiesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                AdvocacyactivitiesService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, AdvocacyactivitiesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                AdvocacyactivitiesService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, AdvocacyactivitiesViewModel db)
        {
            if (db != null)
            {
                AdvocacyactivitiesService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }

    }
}