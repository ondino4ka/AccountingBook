using AccountingBookBL.Providers;
using log4net;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly log4net.ILog Log = LogManager.GetLogger("CategoryController");

        private readonly IProvider _provider;
        public CategoryController(IProvider provider)
        {
            _provider = provider;
        }

        public PartialViewResult CategoriesBar()
        {           
           return PartialView(_provider.GetCategories());
        }
    }
}