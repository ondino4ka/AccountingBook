using log4net;
using AccountingBookBL.Providers;

using System.Web.Mvc;
using System;

namespace AccountingBookWeb.Controllers
{
    public class SubjectController : Controller
    {
        private static readonly log4net.ILog Log = LogManager.GetLogger("SubjectController");

        private readonly IProvider _provider;
        public SubjectController(IProvider provider)
        {
            _provider = provider;
        }

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
    }
}