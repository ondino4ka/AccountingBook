using System;
using System.Collections.Generic;
using System.Web.Mvc;
using log4net;
using AccountingBookCommon;
using AccountingBookBL.Providers;

namespace AccountingBookWeb.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog Log = LogManager.GetLogger("HomeController");

        private readonly IProvider _provider;
        public HomeController(IProvider provider)
        {
            _provider = provider;
        }
        public ActionResult Index()
        {
            Log.Info("Controller:Home; Action:Index");
            return View();
        }    
    }
}