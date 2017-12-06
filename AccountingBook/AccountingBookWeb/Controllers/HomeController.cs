using System.Web.Mvc;
using log4net;
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
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }
    }
}