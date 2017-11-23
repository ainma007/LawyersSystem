using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.TargetGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawyersApp.Models.Attributes;

namespace LawyersApp.Controllers
{
    public class TargetGroupController : Controller
    {
        // GET: TargetGroup
        [SessionTimeout]
        [HttpGet]
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
            return Json(TargetGroupSerivce.Read().Where(t=> t.TargetGroupID<31).ToDataSourceResult(request));
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
                if (ModelState.IsValid)
                {
                    if (user != null)
                    {
                        TargetGroupSerivce.Destroy(user);
                    }
                    return Json(new[] { user }.ToDataSourceResult(request, ModelState));
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("خطأ", "لا يمكن الحذف");
                return Json(new[] { user }.ToDataSourceResult(request, ModelState));

            }
            return Json(new[] { user }.ToDataSourceResult(request, ModelState));



        }
     

    }
}

