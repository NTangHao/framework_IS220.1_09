using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Session.GetString("SessionAdmin") ==null)
            {
                filterContext.Result = new RedirectToRouteResult(new  RouteValueDictionary(new
                {
                    Controller = "Login",
                    Action = "Index"
                }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
