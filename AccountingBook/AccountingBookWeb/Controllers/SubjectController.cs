using AccountingBookBL.Providers;
using AccountingBookCommon;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public PartialViewResult Subjects(int id, bool isCategory)
        {
            return PartialView(_provider.GetSubjectsByCategoryOrSubCategoryId(id, isCategory));
        }

        public PartialViewResult ViewSubject(int inventoryNumber)
        {
            return PartialView(_provider.GetSubjectInformationById(inventoryNumber));
        }
    }
}