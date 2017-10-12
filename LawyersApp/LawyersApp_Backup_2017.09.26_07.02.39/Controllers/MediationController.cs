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

namespace LawyersApp.Controllers
{
    public class MediationController : Controller
    {
        // GET: Mediation
        public ActionResult Mediation()
        {
            PopulateUsers();
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
        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(MediationService.Read().ToDataSourceResult(request));
        }
        public ActionResult Userdb_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(MediationService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString())).ToDataSourceResult(request));
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

    }
}