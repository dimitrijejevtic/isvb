using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace isvb.dev.Models
{
    public class APIAuthorize:AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "ErrorAPI", action = "AccessDenied" }));
            }
        }
    }
}
