using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace AccountingBookWeb.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log = LogManager.GetLogger("HomeController"); 

        // GET: Home
        public ActionResult Index()
        {
            Log.Debug("Test log");
            return View();
        }
    }
}