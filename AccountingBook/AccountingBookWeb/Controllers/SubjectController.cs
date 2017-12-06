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
        public PartialViewResult Subjects(int categoryId)
        {
            try
            {
                return PartialView(_provider.GetSubjectsByCategoryId(categoryId));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView();
            }
        }

        [Ajax]
        public PartialViewResult ViewSubject(int inventoryNumber)
        {
            try
            {
                return PartialView(_provider.GetSubjectInformationById(inventoryNumber));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView();
            }

        }

        [Ajax]
        public PartialViewResult GetSubjectByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            try
            {
                var subjects = _provider.GetSubjectByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
                return PartialView("Subjects", subjects);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView();
            }
            //return PartialView("~/Views/Subject/Subjects.cshtml", subjects);
        }
        [Ajax]
        public JsonResult GetStates()
        {
            try
            {
                if (HttpRuntime.Cache.Get(STATES_KEY) == null)
                {
                    HttpRuntime.Cache.Insert(STATES_KEY, _provider.GetStates());
                }
                return Json(HttpRuntime.Cache.Get(STATES_KEY), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

    }
}