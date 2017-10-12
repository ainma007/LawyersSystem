﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.AwarenessWorkshops;
using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Controllers
{
    public class AwarenessWorkshopsController : Controller
    {
        // GET: AwarenessWorkshops
        public ActionResult AwarenessWorkshops(string projectid)
        {
            Session["Projectid"] = int.Parse(projectid.ToString());
            PopulateUsers();
            return View();
        }
     

        private AwarenessWorkshopsService AwarenessWorkshopsService;
        public AwarenessWorkshopsController()
        {
            AwarenessWorkshopsService = new AwarenessWorkshopsService(new LawyersEntities());
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
            return Json(AwarenessWorkshopsService.Read().Where(u => u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }
        public ActionResult Userdb_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(AwarenessWorkshopsService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, AwarenessWorkshopsViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                AwarenessWorkshopsService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, AwarenessWorkshopsViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                AwarenessWorkshopsService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, AwarenessWorkshopsViewModel db)
        {
            if (db != null)
            {
                AwarenessWorkshopsService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
       

    }
}