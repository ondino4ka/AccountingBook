using AccountingBookBL.Providers;
using AccountingBookWeb.BL.Attributes;
using log4net;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger("CategoryController");

        private readonly IProvider _provider;
        public CategoryController(IProvider provider)
        {
            _provider = provider;
        }

        [Ajax]
        public PartialViewResult CategoriesBar()
        {
            try
            {
                return PartialView(_provider.GetCategories().ToList());
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return PartialView();
            }
        }

        [Ajax]
        public JsonResult GetCategoriesByName(string categoryName)
        {
            try
            {
                return Json(_provider.GetCategoriesByName(categoryName), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}