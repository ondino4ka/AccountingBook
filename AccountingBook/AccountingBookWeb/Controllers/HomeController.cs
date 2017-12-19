using AccountingBookBL.Providers;
using log4net;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger("HomeController");

        private readonly IProvider _provider;
        public HomeController(IProvider provider)
        {
            _provider = provider;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeData()
        {
            return View();
        }      
    }
}