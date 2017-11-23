using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Foreignkey;
using LawyersApp.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawyersApp.Models.Attributes;

namespace LawyersApp.Controllers
{
    public class OrderController : Controller
    {
        [SessionTimeout]
        [HttpGet]
        // GET: Order
        public ActionResult Order( string projectid)
        {
            Session["Projectid"] = int.Parse(projectid.ToString());
            int proid = int.Parse(Session["Projectid"].ToString());
            int UserID = int.Parse(Session["UserID"].ToString());
            if ((string)Session["UserType"] != "1")
            {
                try
                {
                    using (LawyersEntities dc = new LawyersEntities())
                    {
                        // Check If Existed Or Not : 
                        var u = dc.ProjectControl_Table.Single(i => i.UserID == UserID
                                                                    && i.ProjectID == proid &&
                                                                    i.Status == true);
                        if (u != null)
                        {
                            ViewBag.CurrentUser = true;
                        }

                    }
                }
                catch (Exception)
                {

                    ViewBag.CurrentUser = false;

                }

            }
            PopulateIssuesType();
            PopulateUsers();
            PopulateTypeOfCase();
            PopulateCourts();
            PopulateGovernorate();
            PopulateArea();
            return View();
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
        public void PopulateGovernorate()
        {
            var dataContext = new LawyersEntities();
            var Governorate = dataContext.Governorate_Table

                              .Select(c => new GovernorateForeignkey
                              {
                                  Governorate_ID = c.Governorate_ID,
                                  Governorate_Name = c.Governorate_Name
                              })
                              .OrderBy(e => e.Governorate_ID);

            ViewData["Governorate"] = Governorate;
            ViewData["defaultGovernorate"] = Governorate.First();
        }

        public void PopulateArea()
        {
            var dataContext = new LawyersEntities();
            var Area = dataContext.Area_Table

                              .Select(c => new AreaForeignkey
                              {
                                  Area_ID = c.Area_ID,
                                  Area_Name = c.Area_Name
                              })
                              .OrderBy(e => e.Area_ID);

            ViewData["Area"] = Area;
            ViewData["defaultArea"] = Area.First();
        }



        private OrderService OrderService;
        public OrderController()
        {
            OrderService = new OrderService(new LawyersEntities());
        }
        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
            if ((string)Session["UserType"] == "3")
            {

                return Json(OrderService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
            else
            {
                return Json(OrderService.Read().Where(i => i.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
        }


        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, OrderViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                OrderService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, OrderViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                OrderService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, OrderViewModel db)
        {
            if (db != null)
            {
                OrderService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }




        public JsonResult GetUsers()
        {
            return Json(OrderService.GetUsers(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIssuesType()
        {
            return Json(OrderService.GetIssuesType(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTypeOfCase(int IssuesTypeID)
        {
            return Json(OrderService.GetTypeOfCase(IssuesTypeID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourts(int IssuesTypeID)
        {
            return Json(OrderService.GetCourts(IssuesTypeID), JsonRequestBehavior.AllowGet);
        }

       

       
    }
}