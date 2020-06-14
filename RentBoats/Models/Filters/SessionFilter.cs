using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentBoats.Models.Filters
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var user = filterContext.HttpContext.Session.GetString("UserName");
            if (filterContext.HttpContext.Session.GetString("UserName") == null)
            {
                if (((HttpRequest)((Controller)filterContext.Controller).Request).Headers["X-Requested-With"] == "XmlHttpRequest")
                {
                    JsonResult jsonResult = new JsonResult(filterContext);
                    jsonResult.Value = "Session Expired";
                    jsonResult.StatusCode = 440;
                    filterContext.Result = jsonResult;
                }
                else
                {
                    filterContext.Result = new RedirectResult("../../Logon/Logon");
                }
            }
            else
                base.OnActionExecuting(filterContext);
        }
    }
}
