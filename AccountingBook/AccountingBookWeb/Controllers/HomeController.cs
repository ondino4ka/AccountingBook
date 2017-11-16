using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using AccountingBookBL;

namespace AccountingBookWeb.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log = LogManager.GetLogger("HomeController");

        private readonly IDependency dependency;
        public HomeController(IDependency dependency)
        {
            this.dependency = dependency;
        }
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                Log.Debug("Test log");
                throw new Exception("Test Exception");
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
            }
            return Content(dependency.GetMessages());
            }
        }
    }