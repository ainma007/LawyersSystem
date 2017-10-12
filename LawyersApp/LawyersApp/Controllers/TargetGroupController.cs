using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.TargetGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Controllers
{
    public class TargetGroupController : Controller
    {
        // GET: TargetGroup
        public ActionResult TargetGroup()
        {
            return View();
        }

        private TargetGroupSerivce TargetGroupSerivce;
        public TargetGroupController()
        {
            TargetGroupSerivce = new TargetGroupSerivce(new LawyersEntities());
        }
        public ActionResult db_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(TargetGroupSerivce.Read().ToDataSourceResult(request));
        }
        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Create([DataSourceRequest] DataSourceRequest request, TargetGroupViewModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                TargetGroupSerivce.Create(user);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Update([DataSourceRequest] DataSourceRequest request, TargetGroupViewModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                TargetGroupSerivce.Update(user);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult db_Destroy([DataSourceRequest] DataSourceRequest request, TargetGroupViewModel user)
        {
            try
            {
                if (user != null)
                {
                    TargetGroupSerivce.Destroy(user);
                }
                return Json(new[] { user }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception)
            {
                

                return Json(new { Result = "ERROR", Message = "Sorry! unable to delete." });
            }
        }

           
        }

    }
