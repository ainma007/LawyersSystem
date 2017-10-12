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
namespace LawyersApp.Controllers
{
    public class SystemicIssuesController : Controller
    {
        // GET: SystemicIssues
        public ActionResult SystemicIssues()
        {
            PopulateUsers();
            PopulateTypeOfCase();
            PopulateCourts();
            PopulateLawyer();
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

        public void PopulateTypeOfCase()
        {
            var dataContext = new LawyersEntities();
            var typeOfcase = dataContext.TypeOfCase_Table

                              .Select(c => new TypeOfCaseForeignkey
                              {
                                  TypeOfCaseID = c.TypeOfCaseID,
                                  TypeOfCase = c.TypeOfCase
                              })
                              .OrderBy(e => e.TypeOfCaseID);

            ViewData["typeOfcase"] = typeOfcase;
            ViewData["defaultTypeOfCase"] = typeOfcase.First();
        }

        public void PopulateCourts()
        {
            var dataContext = new LawyersEntities();
            var Courts = dataContext.Courts_Table

                              .Select(c => new CourtsForeignkey
                              {
                                  CourtsID = c.CourtsID,
                                  CourtsName = c.CourtsName
                              })
                              .OrderBy(e => e.CourtsID);

            ViewData["Courts"] = Courts;
            ViewData["defaultCourts"] = Courts.First();
        }

        public void PopulateLawyer()
        {
            var dataContext = new LawyersEntities();
            var Lawyer = dataContext.Lawyer_Table

                              .Select(c => new LawyerForeignkey
                              {
                                  LawyerID = c.LawyerID,
                                  LawyerName = c.LawyerName
                              })
                              .OrderBy(e => e.LawyerID);

            ViewData["Lawyer"] = Lawyer;
            ViewData["defaultLawyer"] = Lawyer.First();
        }


        private SystemicIssuesService SystemicIssuesService;
        public SystemicIssuesController()
        {
            SystemicIssuesService = new SystemicIssuesService(new LawyersEntities());
        }
        public ActionResult Systemic_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(SystemicIssuesService.Read().ToDataSourceResult(request));
        }

        public ActionResult UserSystemic_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(SystemicIssuesService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString())).ToDataSourceResult(request));
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

    }
}