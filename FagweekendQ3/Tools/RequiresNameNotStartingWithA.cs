using System;
using System.Web;
using System.Web.Mvc;

namespace FagweekendQ3.Tools
{
    public class RequiresNameNotStartingWithA : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var name = HttpContext.Current.User.Identity.Name;

            if(name.StartsWith("a"))
                throw new UnauthorizedAccessException("People with names staring with a is not allowed to enter this application");
        }
    }
}