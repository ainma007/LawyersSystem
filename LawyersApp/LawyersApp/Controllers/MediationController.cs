using LawyersApp.Models.Mediation;
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
    public class MediationController : Controller
    {
        // GET: Mediation
        [SessionTimeout]
        [HttpGet]
        public ActionResult Mediation(string projectid)
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
            PopulateDiligenceType();
            PopulateGovernorate();
            PopulateArea();
            return View();
        }

        private MediationService MediationService;
        public MediationController()
        {
            MediationService = new MediationService(new LawyersEntities());
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

        public void PopulateIssuesType()
        {
            //  وهنا كمان لازم يكون نشيط حتى يتم ادراجه في المشاريع
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

        public void PopulateDiligenceType()
        {
            //  وهنا كمان لازم يكون نشيط حتى يتم ادراجه في المشاريع
            var dataContext = new LawyersEntities();
            var DiligenceType = dataContext.DiligenceType_Table

                              .Select(c => new DiligenceTypeForeingKey
                              {
                                  DiligenceTypeID = c.DiligenceTypeID,
                                  DiligenceTypeName = c.DiligenceTypeName
                              })
                              .OrderBy(e => e.DiligenceTypeID);

            ViewData["DiligenceType"] = DiligenceType;
            ViewData["defaultDiligenceType"] = DiligenceType.First();
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
                return Json(MediationService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
            else
            {
                return Json(MediationService.Read().Where(P => P.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
        }
    
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, MediationViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                MediationService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, MediationViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                MediationService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, MediationViewModel db)
        {
            if (db != null)
            {
                MediationService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult GetIssuesType()
        {
            return Json(MediationService.GetIssuesType(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDiligenceType()
        {
            return Json(MediationService.GetDiligenceType(), JsonRequestBehavior.AllowGet);
        }

    }
}