using System;
using System.Web;
using System.Web.Mvc;
using log4net;
using AccountingBookBL.Providers;
using AccountingBookWeb.BL.Attributes;


namespace AccountingBookWeb.Controllers
{
    public class SubjectController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger("SubjectController");
        private const string STATES_KEY = "states_key";

        private readonly IProvider _provider;
        public SubjectController(IProvider provider)
        {
            _provider = provider;
        }

        [Ajax]
        public PartialViewResult GetSubjectsByCategoryId(int categoryId)
        {
            try
            {
                return PartialView("Subjects", _provider.GetSubjectsByCategoryId(categoryId));
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return PartialView("Subjects");
            }
        }


        public ActionResult SearchSubjects()
        {
            return View();
        }

        [Ajax]
        public PartialViewResult ViewSubject(int inventoryNumber)
        {
            try
            {
                return PartialView(_provider.GetSubjectInformationById(inventoryNumber));
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return PartialView();
            }

        }

        [Ajax]
        public PartialViewResult GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            try
            {
                var subjects = _provider.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
                return PartialView("Subjects", subjects);
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return PartialView("Subjects");
            }
        }
        [Ajax]
        public JsonResult GetStates()
        {
            try
            {
                if (HttpRuntime.Cache.Get(STATES_KEY) == null)
                {
                    HttpRuntime.Cache.Insert(STATES_KEY, _provider.GetStates(), null, DateTime.Now.AddMinutes(60), TimeSpan.Zero);
                }
                return Json(HttpRuntime.Cache.Get(STATES_KEY), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}