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
using LawyersApp.Models.Attributes;
using LawyersApp.Models.Beneficiaries;

namespace LawyersApp.Controllers
{
    
    public class LegalIssuesController : Controller
    {

        [SessionTimeout]
        [HttpGet]

        public ActionResult LegalIssues(string projectid)
        {
            
            Session["Projectid"] = int.Parse(projectid.ToString());
           int  proid = int.Parse(Session["Projectid"].ToString());
           int  UserID = int.Parse(Session["UserID"].ToString());
            if ((string)Session["UserType"] != "1") {
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
           
            PopulateUsers();
            PopulateTypeOfCase();
            PopulateCourts();
            PopulateIssuesStatus();
            PopulateGovernorate();
            PopulateArea();
           
            return View();
        
        }
        public void PopulateIssuesStatus()
        {
            //  وهنا كمان لازم يكون نشيط حتى يتم ادراجه في المشاريع
            var dataContext = new LawyersEntities();
            var IssuesStatus = dataContext.IssuesStatus_Table


                              .Select(c => new IssuesStatusForeignkey
                              {
                                  IssuesStatusID = c.IssuesStatusID,
                                  IssuesStatusName = c.IssuesStatusName
                              })
                              .OrderBy(e => e.IssuesStatusID);

            ViewData["IssuesStatus"] = IssuesStatus;
            ViewData["defaultIssuesStatus"] = IssuesStatus.First();
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
                .Where(c=> c.IssuesTypeID==2)

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
                .Where(c => c.IssuesTypeID == 2)
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



        private LegalIssuesService LegalIssuesService;
        public LegalIssuesController()
        {
            LegalIssuesService = new LegalIssuesService(new LawyersEntities());
        }
        public ActionResult Legal_Read([DataSourceRequest] DataSourceRequest request)
        {
            if ((string)Session["UserType"] == "3") {

                return Json(LegalIssuesService.Read().Where(u => u.UserID == int.Parse(Session["UserID"].ToString()) && u.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
            else
            {
                return Json(LegalIssuesService.Read().Where(i => i.ProjectID == int.Parse(Session["Projectid"].ToString())).ToDataSourceResult(request));

            }
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

        //public JsonResult GetBeneficiaries()
        //{
        //    return Json(LegalIssuesService.GetBeneficiaries(), JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetGovernorate()
        //{
        //    return Json(LegalIssuesService.GetGovernorate(), JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetArea(int Governorate_ID)
        //{
        //    return Json(LegalIssuesService.GetArea(Governorate_ID), JsonRequestBehavior.AllowGet);
        //}



        public JsonResult GetIssuesStatus()
        {
            return Json(LegalIssuesService.GetIssuesStatus(), JsonRequestBehavior.AllowGet);
        }



        public ActionResult Virtualization_Read([DataSourceRequest] DataSourceRequest request)
        {
           

            return Json(GetBeneficiaries().ToDataSourceResult(request));
        }

        

        private static IEnumerable<BeneficiariesForeignkey> GetBeneficiaries()
        {
            var northwind = new LawyersEntities();

            return northwind.Beneficiaries_Table.Select(order => new BeneficiariesForeignkey
            {
                BeneficiariesIDNumber = order.BeneficiariesIDNumber,
                BeneficiariesName = order.BeneficiariesName,

                Beneficiaries_ID = order.Beneficiaries_ID


              
            });
        }


        public JsonResult GetGovernorate()
        {
            var northwind = new LawyersEntities();


            var province = northwind.Governorate_Table.Select(db => new GovernorateForeignkey
            {
                Governorate_ID = db.Governorate_ID,
                Governorate_Name = db.Governorate_Name
            });


            return Json(province, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetArea(int Governorate_ID)
        {
            var northwind = new LawyersEntities();


            var province = northwind.Area_Table.Where(m => m.Governorate_ID == Governorate_ID).Select(db => new AreaForeignkey
            {
                Area_ID = db.Area_ID,
                Area_Name = db.Area_Name
            });




            return Json(province, JsonRequestBehavior.AllowGet);
        }

       

    }
}

