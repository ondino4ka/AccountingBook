using AccountingBookWeb.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AccountingBookWeb.BL.Attributes
{
    public class OnlyAnonymousAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.User as UserPrincipal;
            if (user != null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }
    }
}