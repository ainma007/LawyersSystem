using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LawyersApp.Models;
using LawyersApp.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private ProjectService ProjectService;
        public HomeController()
        {
            ProjectService = new ProjectService(new LawyersEntities());

        }

        public ActionResult ProjectMainAdmin_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ProjectService.Read().ToDataSourceResult(request));
        }

        public ActionResult ProjectMainUser_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ProjectService.UserDread().Where(e=> e.UserID==int.Parse(Session["UserID"].ToString())).ToDataSourceResult(request));
        }
    }
}
