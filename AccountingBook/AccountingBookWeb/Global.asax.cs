using AccountingBookCommon.Models;
using AccountingBookWeb.Controllers;
using AccountingBookWeb.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace AccountingBookWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();          
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var auth = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (auth != null)
            {
                var ticket = FormsAuthentication.Decrypt(auth.Value);
                var model = JsonConvert.DeserializeObject<UserAuthorization>(ticket.UserData);
                var principal = new UserPrincipal(ticket.Name);
                principal.Name = model.Name;
                principal.Roles = model.Roles.Select(x => x.RoleName).ToArray();
                HttpContext.Current.User = principal;
            }
        }
        public void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Server.ClearError();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "ErrorPage");
            routeData.Values.Add("exception", exception);

            if (exception.GetType() == typeof(HttpException))
            {
                routeData.Values.Add("statusCode", ((HttpException)exception).GetHttpCode());
            }
            else
            {
                routeData.Values.Add("statusCode", 500);
            }

            Response.TrySkipIisCustomErrors = true;
            IController controller = new ErrorController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            Response.End();
        }
    }
}
