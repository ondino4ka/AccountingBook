using AccountingBookWeb.Models;
using System.Web;
using System.Web.Mvc;

namespace AccountingBookWeb.BL.Attributes
{
    public class AdminAttribute : OnlyAnonymousAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.User as UserPrincipal;
            if (user == null || !user.IsInRole("Admin"))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "AccessDenied" }));
            }
        }
    }
}