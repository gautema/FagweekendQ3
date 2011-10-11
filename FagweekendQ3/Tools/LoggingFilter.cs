using System.Diagnostics;
using System.Web.Mvc;

namespace FagweekendQ3.Tools
{
    public class LoggingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine(string.Format("Loaded {0} in {1}", filterContext.ActionDescriptor.ActionName, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName));
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine(string.Format("Exited {0} in {1}", filterContext.ActionDescriptor.ActionName, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName));
        }
    }
}