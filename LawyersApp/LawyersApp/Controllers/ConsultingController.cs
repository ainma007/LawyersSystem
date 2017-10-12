using LawyersApp.Models.Consulting;
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
    public class ConsultingController : Controller
    {
        // GET: Consulting
        public ActionResult Consulting(string projectid)
        {
            Session["Projectid"] = int.Parse(projectid.ToString());
            PopulateUsers();
            PopulateIssuesType();
            PopulateTypeOfCase();
            PopulateLawyer();
            return View();
        }

        private ConsultingService ConsultingService;
        public ConsultingController()
        {
            ConsultingService = new ConsultingService(new LawyersEntities());
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

        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ConsultingService.Read().Where(i => i.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }
        public ActionResult Userdb_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ConsultingService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, ConsultingViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ConsultingService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, ConsultingViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ConsultingService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, ConsultingViewModel db)
        {
            if (db != null)
            {
                ConsultingService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        public JsonResult GetTypeOfCase(int IssuesTypeID)
        {
            return Json(ConsultingService.GetTypeOfCase(IssuesTypeID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIssuesType()
        {
            return Json(ConsultingService.GetIssuesType(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLawyer()
        {
            return Json(ConsultingService.GetLawyer(), JsonRequestBehavior.AllowGet);
        }
    }
}