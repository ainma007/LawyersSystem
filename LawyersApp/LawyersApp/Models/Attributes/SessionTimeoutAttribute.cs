using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyersApp.Models.Attributes
{
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
       
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpContext ctx = HttpContext.Current;
                if (HttpContext.Current.Session["UserID"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Account/Login");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
       
    }
}