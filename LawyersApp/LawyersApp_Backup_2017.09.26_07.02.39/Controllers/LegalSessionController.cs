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
    public class LegalSessionController : Controller
    {
        // GET: LegalSession
        public ActionResult LegalSession()
        {
            return View();
        }
        private LegalSessionService LegalSessionService;
        public LegalSessionController()
        {
            LegalSessionService = new LegalSessionService(new LawyersEntities());
        }
        public void PopulateUsers()
        {
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
            return Json(LegalSessionService.Read().ToDataSourceResult(request));
        }
        public ActionResult Userdb_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(LegalSessionService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString())).ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, LegalSessionViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                LegalSessionService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, LegalSessionViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                LegalSessionService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, LegalSessionViewModel db)
        {
            if (db != null)
            {
                LegalSessionService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


    }
}