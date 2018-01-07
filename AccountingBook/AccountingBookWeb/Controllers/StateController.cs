using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookWeb.BL.Attributes;
using log4net;
using System;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class StateController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger("StateController");
        private readonly IStateProvider _stateProvider;
        private readonly IStateService _stateService;
        public StateController(IStateProvider stateProvider, IStateService stateService)
        {
            _stateProvider = stateProvider;
            _stateService = stateService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult ListStates()
        {
            try
            {
                return View(_stateProvider.GetStates());
            }
            catch (Exception)
            {
                return View();
            }
        }

        [Ajax]
        public JsonResult GetStates()
        {
            try
            {
                return Json(_stateProvider.GetStates(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult AddEditState(int? Id)
        {
            if (!Id.HasValue)
            {
                return View(new State());
            }
            try
            {
                State state = _stateProvider.GetStateById((int)Id);
                if (state != null)
                {
                    return View(state);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult AddEditState(State state)
        {
            if (string.IsNullOrEmpty(state.StateName) || state.StateName.Length < 6 || state.StateName.Length > 50)
            {
                return View(state);
            }
            try
            {
                if (state.Id != 0)
                {
                    _stateService.EditState(state.Id, state.StateName);
                }
                else
                {
                    _stateService.AddState(state.StateName);
                }
                return RedirectToAction("ListStates");
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View(state);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult DeleteState(int Id)
        {
            try
            {
                State state = _stateProvider.GetStateById(Id);
                if (state != null)
                {
                    return View(state);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View();
            }
        }

        [HttpPost, ActionName("DeleteState")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult DeleteConfirmed(int Id)
        {
            try
            {
                _stateService.DeleteStateById(Id);
                return RedirectToAction("ListStates");
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View();
            }
        }
    }
}