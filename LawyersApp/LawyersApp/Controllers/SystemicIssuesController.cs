using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Foreignkey;
using LawyersApp.Models.SystemicIssues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawyersApp.Models.Attributes;
using LawyersApp.Models.Beneficiaries;

namespace LawyersApp.Controllers
{
    public class SystemicIssuesController : Controller
    {
        // GET: SystemicIssues
        [SessionTimeout]
        [HttpGet]
        public ActionResult SystemicIssues()
        {
           
           
            PopulateUsers();
            PopulateTypeOfCase();
            PopulateCourts();
            PopulateIssuesStatus();
            PopulateGovernorate();
            PopulateArea();
            return View();
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

        public void PopulateIssuesStatus()
        {
            //  وهنا كمان لازم يكون نشيط حتى يتم ادراجه في المشاريع
            var dataContext = new LawyersEntities();
            var IssuesStatus = dataContext.IssuesStatus_Table


                              .Select(c => new IssuesStatusForeignkey
                              {
                                  IssuesStatusID = c.IssuesStatusID,
                                  IssuesStatusName = c.IssuesStatusName
                              })
                              .OrderBy(e => e.IssuesStatusID);

            ViewData["IssuesStatus"] = IssuesStatus;
            ViewData["defaultIssuesStatus"] = IssuesStatus.First();
        }

        public void PopulateTypeOfCase()
        {
            var dataContext = new LawyersEntities();
            var typeOfcase = dataContext.TypeOfCase_Table
                .Where(c => c.IssuesTypeID == 1)

                              .Select(c => new TypeOfCaseForeignkey 
                              {
                                  TypeOfCaseID = c.TypeOfCase_ID,
                                  TypeOfCase = c.TypeOfCaseName
                              })
                              
                              .OrderBy(e => e.TypeOfCaseID);
            
            ViewData["typeOfcase"] = typeOfcase;
            ViewData["defaultTypeOfCase"] = typeOfcase.First();
        }

        public void PopulateCourts()
        {
            var dataContext = new LawyersEntities();
            var Courts = dataContext.Courts_Table
                .Where(c => c.IssuesTypeID == 1)

                              .Select(c => new CourtsForeignkey
                              {
                                  CourtsID = c.CourtsID,
                                  CourtsName = c.CourtsName
                              })
                              .OrderBy(e => e.CourtsID);

            ViewData["Courts"] = Courts;
            ViewData["defaultCourts"] = Courts.First();
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


        private SystemicIssuesService SystemicIssuesService;
        public SystemicIssuesController()
        {
            SystemicIssuesService = new SystemicIssuesService(new LawyersEntities());
        }
        public ActionResult Systemic_Read([DataSourceRequest] DataSourceRequest request)
        {
            if ((string)Session["UserType"] == "3")
            {
                return Json(SystemicIssuesService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString())).ToDataSourceResult(request));

            }
            else
            {
                return Json(SystemicIssuesService.Read().ToDataSourceResult(request));

            }
        }

     
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Systemic_Create([DataSourceRequest] DataSourceRequest request, SystemicIssuesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                SystemicIssuesService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Systemic_Update([DataSourceRequest] DataSourceRequest request, SystemicIssuesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                SystemicIssuesService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Systemic_Destroy([DataSourceRequest] DataSourceRequest request, SystemicIssuesViewModel db)
        {
            if (db != null)
            {
                SystemicIssuesService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }




        public JsonResult GetUsers()
        {
            return Json(SystemicIssuesService.GetUsers(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTypeOfCase()
        {
            return Json(SystemicIssuesService.GetTypeOfCase(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourts()
        {
            return Json(SystemicIssuesService.GetCourts(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLawyer()
        {
            return Json(SystemicIssuesService.GetLawyer(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetIssuesStatus()
        {
            return Json(SystemicIssuesService.GetIssuesStatus(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSystemicIssues()
        {
            if ((string)Session["UserType"] == "1")
            {

                return Json(SystemicIssuesService.GetSystemicIssues(), JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(SystemicIssuesService.GetSystemicIssues().Where(s=> s.UserID== int.Parse(Session["UserID"].ToString())), JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult SystemicIssuesProject( string projectid)
        {
            Session["Projectid"] = int.Parse(projectid.ToString());
            int proid = int.Parse(Session["Projectid"].ToString());
            int UserID = int.Parse(Session["UserID"].ToString());
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
            PopulateUsers();
            PopulateTypeOfCase();
            PopulateCourts();
            PopulateIssuesStatus();
            return View();
        }

        public ActionResult SystemicProject_Read([DataSourceRequest] DataSourceRequest request)
        {
            if ((string)Session["UserType"] == "3")
            {
                return Json(SystemicIssuesService.ProjectRead().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
            else
            {
                return Json(SystemicIssuesService.ProjectRead().Where(i => i.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult SystemicProject_Create([DataSourceRequest] DataSourceRequest request, SystemicIssuesProjectViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                SystemicIssuesService.ProjectCreate(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult SystemicProject_Update([DataSourceRequest] DataSourceRequest request, SystemicIssuesProjectViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                SystemicIssuesService.ProjectUpdate(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult SystemicProject_Destroy([DataSourceRequest] DataSourceRequest request, SystemicIssuesProjectViewModel db)
        {
            if (db != null)
            {
                SystemicIssuesService.ProjectDestroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult ADDBenef(BeneficiariesViewModel db)
        {
            LawyersEntities entities = new LawyersEntities();
            var entity = new Beneficiaries_Table();
            entity.BeneficiariesIDNumber = db.BeneficiariesIDNumber;

            entity.BeneficiariesName = db.BeneficiariesName;

            entity.BeneficiariesPhone = db.BeneficiariesPhone;
            entity.GenderID = db.GenderID;

            entities.Beneficiaries_Table.Add(entity);
            entities.SaveChanges();

            db.Beneficiaries_ID = entity.Beneficiaries_ID;
            return View();
        }

    }
}