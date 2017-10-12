using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Foreignkey;
using LawyersApp.Models.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media
        public ActionResult Media( string projectid)
        {
            Session["Projectid"] = int.Parse(projectid.ToString());
            PopulateMediaType();
            PopulateUsers();
            return View();
        }

        private MediaService MediaService;
        public MediaController()
        {
            MediaService = new MediaService(new LawyersEntities());
        }
        public void PopulateMediaType()
        {
            var dataContext = new LawyersEntities();
            var MediaType = dataContext.MediaType_Table

                              .Select(c => new MediaTypeForingKey
                              {
                                  MediaTypeID = c.MediaTypeID,
                                  MediaTypeName = c.MediaTypeName
                              })
                              .OrderBy(e => e.MediaTypeID);

            ViewData["MediaType"] = MediaType;
            ViewData["defaultMediaType"] = MediaType.First();
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
            return Json(MediaService.Read().Where(u => u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }
        public ActionResult Userdb_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(MediaService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, MediaViewControl db)
        {
            if (db != null && ModelState.IsValid)
            {
                MediaService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, MediaViewControl db)
        {
            if (db != null && ModelState.IsValid)
            {
                MediaService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, MediaViewControl db)
        {
            if (db != null)
            {
                MediaService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        public JsonResult GetMediaType()
        {
            return Json(MediaService.GetMediaType(), JsonRequestBehavior.AllowGet);
        }
    }
}