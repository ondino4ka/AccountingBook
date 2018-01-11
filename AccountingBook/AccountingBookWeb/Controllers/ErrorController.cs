using log4net;
using System;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class ErrorController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger("ErrorController");
        public ActionResult ErrorPage(int statusCode, Exception exception)
        {
            Log.Error(exception.Message);
            Response.StatusCode = statusCode;
            if (statusCode == 500)
            {
                ViewBag.StatusCode = statusCode + " Internal server error";
            }
            else if (statusCode == 404)
            {
                ViewBag.StatusCode = statusCode + " Page not found";
            }
            else
            {
                ViewBag.StatusCode = "Internal server error. Try later";
            }       
            return View();
        }
    }
}