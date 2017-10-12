using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Foreignkey;
using LawyersApp.Models.LegalIssues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Controllers
{
    public class LegalIssuesController : Controller
    {
        // GET: LegalIssues
        public ActionResult LegalIssues(string projectid)
        {
            Session["Projectid"] = int.Parse(projectid.ToString());
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


        private LegalIssuesService LegalIssuesService;
        public LegalIssuesController()
        {
            LegalIssuesService = new LegalIssuesService(new LawyersEntities());
        }
        public ActionResult Legal_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(LegalIssuesService.Read().Where(i=> i.ProjectID== int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }

        public ActionResult UserLegal_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(LegalIssuesService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Legal_Create([DataSourceRequest] DataSourceRequest request, LegalIssuesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                LegalIssuesService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Legal_Update([DataSourceRequest] DataSourceRequest request, LegalIssuesViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                LegalIssuesService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Legal_Destroy([DataSourceRequest] DataSourceRequest request, LegalIssuesViewModel db)
        {
            if (db != null)
            {
                LegalIssuesService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }




        public JsonResult GetUsers()
        {
            return Json(LegalIssuesService.GetUsers(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTypeOfCase()
        {
            return Json(LegalIssuesService.GetTypeOfCase(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourts()
        {
            return Json(LegalIssuesService.GetCourts(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLawyer()
        {
            return Json(LegalIssuesService.GetLawyer(), JsonRequestBehavior.AllowGet);
        }
    }
}