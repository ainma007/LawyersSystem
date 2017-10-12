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
        public ActionResult Consulting()
        {
            PopulateUsers();
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
        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ConsultingService.Read().ToDataSourceResult(request));
        }
        public ActionResult Userdb_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ConsultingService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString())).ToDataSourceResult(request));
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

    }
}