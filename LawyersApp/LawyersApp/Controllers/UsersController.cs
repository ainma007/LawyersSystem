﻿using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using LawyersApp.Models;
using LawyersApp.Models.Users;
using LawyersApp.Models.Attributes;

namespace LawyersApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [SessionTimeout]
        [HttpGet]
        public ActionResult UserManegment()
        {
           
            return View();
        }

        private UserService UserService;
        public UsersController()
        {
            UserService = new UserService(new LawyersEntities());
        }
        public ActionResult User_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(UserService.Read().ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult User_Create([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                UserService.Create(user);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult User_Update([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                UserService.Update(user);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult User_Destroy([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (user != null)
                    {
                        UserService.Destroy(user);
                    }
                   
                }
                catch (Exception)
                {

                    ModelState.AddModelError("خطأ", "لا يمكن الحذف");
                    return Json(new[] { user }.ToDataSourceResult(request, ModelState));

                }
               
            }
            return Json(new[] { user }.ToDataSourceResult(request, ModelState));

        }

    }
}