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
        private static log4net.ILog Log = LogManager.GetLogger("HomeController");

        private readonly IProvider dependency;
        public HomeController(IProvider dependency)
        {
            this.dependency = dependency;
        }
        // GET: Home
        public ActionResult Index()
        {
            //try
            //{
            //    Log.Debug("Test log");
            //    throw new Exception("Test Exception");
            //}
            //catch (Exception exception)
            //{
            //    Log.Error(exception.Message);
            //}
            //return Content(dependency.GetMessages());
            return View();
        }
        public PartialViewResult CategoriesBar()
        {
            var categories = dependency.GetCategories();
            return PartialView(categories);
        }
        public PartialViewResult Subjects(int id, bool isCategory)
        {
            IReadOnlyList<Subject> subjects = dependency.GetSubjectsByCategoryOrSubCategoryId(id, isCategory);
            return PartialView(subjects);
        }
        public PartialViewResult ViewSubject(int inventoryNumber)
        {
            return PartialView(dependency.GetSubjectInformationById(inventoryNumber));
        }
    }
}