using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Attributes;
using LawyersApp.Models.Foreignkey;
using LawyersApp.Models.Legal_Assistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Controllers
{
    public class Legal_AssistanceController : Controller
    {

        [SessionTimeout]
        [HttpGet]
        // GET: Legal_Assistance
        public ActionResult Legal_Assistance(string projectid)
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
            PopulateIssuesType();
            PopulateTypeOfCase();
            PopulateGovernorate();
            PopulateArea();
            return View();
        }


        private Legal_AssistanceService Legal_AssistanceService;
        public Legal_AssistanceController()
        {
            Legal_AssistanceService = new Legal_AssistanceService(new LawyersEntities());
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
        public void PopulateTypeOfCase()
        {
            var dataContext = new LawyersEntities();
            var typeOfcase = dataContext.TypeOfCase_Table

                              .Select(c => new TypeOfCaseForeignkey
                              {
                                  TypeOfCaseID = c.TypeOfCase_ID,
                                  TypeOfCase = c.TypeOfCaseName
                              })
                              .OrderBy(e => e.TypeOfCaseID);

            ViewData["typeOfcase"] = typeOfcase;
            ViewData["defaultTypeOfCase"] = typeOfcase.First();
        }
        public void PopulateGovernorate()
        {
            var dataContext = new LawyersEntities();
            var Governorate = dataContext.Governorate_Table

                              .Select(c => new GovernorateForeignkey
                              {
                                  Governorate_ID = c.Governorate_ID,
                                  Governorate_Name = c.Governorate_Name
                              })
                              .OrderBy(e => e.Governorate_ID);

            ViewData["Governorate"] = Governorate;
            ViewData["defaultGovernorate"] = Governorate.First();
        }

        public void PopulateArea()
        {
            var dataContext = new LawyersEntities();
            var Area = dataContext.Area_Table

                              .Select(c => new AreaForeignkey
                              {
                                  Area_ID = c.Area_ID,
                                  Area_Name = c.Area_Name
                              })
                              .OrderBy(e => e.Area_ID);

            ViewData["Area"] = Area;
            ViewData["defaultArea"] = Area.First();
        }

        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
            if ((string)Session["UserType"] == "3")
            {
                return Json(Legal_AssistanceService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
            else
            {
                return Json(Legal_AssistanceService.Read().Where(i => i.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
        }

        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, Legal_AssistanceViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                Legal_AssistanceService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, Legal_AssistanceViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                Legal_AssistanceService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, Legal_AssistanceViewModel db)
        {
            if (db != null)
            {
                Legal_AssistanceService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        public JsonResult GetTypeOfCase(int IssuesTypeID)
        {
            return Json(Legal_AssistanceService.GetTypeOfCase(IssuesTypeID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIssuesType()
        {
            return Json(Legal_AssistanceService.GetIssuesType(), JsonRequestBehavior.AllowGet);
        }

    }
}