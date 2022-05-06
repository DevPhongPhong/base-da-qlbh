using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Web.Areas.Administrator.Controllers
{
    public class BaseController : Controller, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            if (actionExecutingContext.HttpContext.Session.GetString("user") == null)
            {
                actionExecutingContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index",
                    //returnurl = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(actionExecutingContext.HttpContext.Request)
                }));
            }
            else
            {
                TempData["user"] = actionExecutingContext.HttpContext.Session.GetString("user");
                TempData["RoleId"] = actionExecutingContext.HttpContext.Session.GetString("roleid");
                base.OnActionExecuting(actionExecutingContext);
            }
        }

        protected void SetAlert(string type, string message)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "error";
            }
            else
            {
                TempData["AlertType"] = "info";
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
