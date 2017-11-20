using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using AccountingBookBL;
using AccountingBookCommon;

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
            IReadOnlyList<Subject> subjects;
            if (isCategory)
            {
                subjects = dependency.GetSubjectsByCategories(id);
            }
            else
            {
                subjects = dependency.GetSubjectsBySubCategories(id);
            }
            return PartialView(subjects);
        }
        public PartialViewResult ViewSubject(int inventoryNumberSubject)
        {
            ViewBag.NameCategory = dependency.GetNameSubCategoryBySubjectId(inventoryNumberSubject);
            return PartialView(dependency.GetSubjectInformationById(inventoryNumberSubject));
        }
    }
}