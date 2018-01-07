using AccountingBookBL.Providers;
using log4net;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        } 
    }
}