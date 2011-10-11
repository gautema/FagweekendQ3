using System.Web;
using System.Web.Mvc;

namespace FagweekendQ3.Tools
{
    public class UserFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                var name = HttpContext.Current.User.Identity.Name;
                viewResult.ViewBag.UserName = name;
            }

        }
    }
}