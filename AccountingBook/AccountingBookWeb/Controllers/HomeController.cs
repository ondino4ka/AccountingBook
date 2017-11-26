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

        private readonly IProvider dependency;
        public HomeController(IProvider dependency)
        {
            this.dependency = dependency;
        }
        public ActionResult Index()
        {
            Log.Info("Controller:Home; Action:Index");
            return View();
        }
        public PartialViewResult CategoriesBar()
        {
            var categories = dependency.GetCategories();
            return PartialView(categories);
        }
        public PartialViewResult Subjects(int id, bool isCategory)
        {
            IReadOnlyList<SubjectDetails> subjects = dependency.GetSubjectsByCategoryOrSubCategoryId(id, isCategory);
            return PartialView(subjects);
        }
        public PartialViewResult ViewSubject(int inventoryNumber)
        {
            return PartialView(dependency.GetSubjectInformationById(inventoryNumber));
        }
    }
}