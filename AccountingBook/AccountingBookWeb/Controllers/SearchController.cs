using System.Web.Mvc;
using log4net;
using AccountingBookBL.Providers;

namespace AccountingBookWeb.Controllers
{
    public class SearchController : Controller
    {

        private static readonly ILog Log = LogManager.GetLogger("SearchController");

        private readonly IProvider _provider;
        public SearchController(IProvider provider)
        {
            _provider = provider;
        }

        public ActionResult Index()
        {
            SelectList categories = new SelectList(_provider.GetCategories(), "Id", "Name");
            ViewBag.Categories = categories;
            return View();
        }
    }
}