using System;
using System.Linq;
using System.Web.Mvc;
using log4net;
using AccountingBookBL.Providers;
using AccountingBookWeb.BL.Attributes;

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
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView();
            }          
        }

        [Ajax]
        public JsonResult GetCategoriesByName(string categoryName)
        {
            return Json(_provider.GetCategoriesByName(categoryName), JsonRequestBehavior.AllowGet);
        }
    }
}