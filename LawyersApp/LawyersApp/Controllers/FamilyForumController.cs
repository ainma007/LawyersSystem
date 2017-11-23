using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.FamilyForum;
using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawyersApp.Models.Attributes;


namespace LawyersApp.Controllers
{
    [SessionTimeout]
    public class FamilyForumController : Controller
    {
        // GET: FamilyForum
        
        [HttpGet]
        public ActionResult FamilyForum()
        {
         
          
            PopulateUsers();

            return View();

        }
        [HttpGet]
        public ActionResult FamilyWatch( string familyformID)
        {

            Session["familyformID"] = int.Parse(familyformID.ToString());
            FamilyInfo();
            PopulateUsers();
            return View();

        }
        private FamilyForumService FamilyForumService;
        public FamilyForumController()
        {
            FamilyForumService = new FamilyForumService(new LawyersEntities());
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
        public void FamilyInfo()
        {
            int h = 0;
            h = int.Parse(Session["familyformID"].ToString());
            try
            {
                using (LawyersEntities dc = new LawyersEntities())
                {
                    // Check If Existed Or Not : 
                    var u = dc.FamilyForum_Table.Single(i => i.FamilyForumID == h
                                                                );
                    if (u != null)
                    {

                       ViewBag.ApplicantName = u.ApplicantName;
                        ViewBag.CustodialName = u.CustodialName;
                       
                    }
                }

            }
            catch (Exception)
            {
                //اذا كان المستخدم اساسا مش موجود في جدول المستخدمين او كلمة المرور خطأ
                ModelState.AddModelError("", "خطأ في الدخول للنظام");
            }
        }
        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
            
                return Json(FamilyForumService.Read().ToDataSourceResult(request));

           
        }
      
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, FamilyForumViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                FamilyForumService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, FamilyForumViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                FamilyForumService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, FamilyForumViewModel db)
        {
            if (db != null)
            {
                FamilyForumService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }

        // ملاحظات المشاهدات 
        public ActionResult db_ReadWatch([DataSourceRequest] DataSourceRequest request)
        {

            return Json(FamilyForumService.ReadWatch().Where(f => f.FamilyForumID == int.Parse(Session["familyformID"].ToString())).ToDataSourceResult(request));


        }

        public ActionResult db_CreateWatch([DataSourceRequest] DataSourceRequest request, FamilyWatchViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                FamilyForumService.CreateWatch(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_UpdateWatch([DataSourceRequest] DataSourceRequest request, FamilyWatchViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                FamilyForumService.UpdateWatch(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_DestroyWatch([DataSourceRequest] DataSourceRequest request, FamilyWatchViewModel db)
        {
            if (db != null)
            {
                FamilyForumService.DestroyWatch(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
    }
}