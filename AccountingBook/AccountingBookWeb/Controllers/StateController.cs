using AccountingBookBL.Operations;
using AccountingBookBL.Providers;
using AccountingBookCommon.Models;
using System;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class StateController : Controller
    {
        private readonly IProvider _provider;
        private readonly IStateOperation _stateOperation;
        public StateController(IProvider provider, IStateOperation stateOperation)
        {
            _provider = provider;
            _stateOperation = stateOperation;
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult ListStates()
        {
            try
            {
                return View(_provider.GetStates());
            }
            catch (Exception)
            {
                return View();
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
                State state = _provider.GetStateById((int)Id);
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
            if (string.IsNullOrEmpty(state.StateName) || state.StateName.Length < 6)
            {
                return View(state);
            }
            try
            {
                if (state.Id != 0)
                {
                    _stateOperation.EditState(state.Id, state.StateName);
                }
                else
                {
                    _stateOperation.AddState(state.StateName);
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
                State state = _provider.GetStateById(Id);
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
                _stateOperation.DeleteStateById(Id);
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