using AccountingBookBL.Operations;
using AccountingBookBL.Providers;
using AccountingBookCommon.Models;
using AccountingBookWeb.BL.Attributes;
using System;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class LocationController : Controller
    {
        private readonly IProvider _provider;
        private readonly ILocationOperation _location;
        public LocationController(IProvider provider, ILocationOperation location)
        {
            _provider = provider;
            _location = location;
        }

        public ActionResult SearchLocations()
        {
            return View();
        }

        [Ajax]
        [Authorize(Roles = "Admin, Edit")]
        public JsonResult GetLocations()
        {
            try
            {
                return Json(_provider.GetLocations(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {             
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [Ajax]
        [Authorize(Roles = "Admin, Edit")]
        public PartialViewResult GetLocationsByAddress(string address)
        {
            try
            {
                return PartialView("Locations", _provider.GetLocationsByAddress(address));
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return PartialView("Locations");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult AddEditLocation(int? Id)
        {
            if (!Id.HasValue)
            {
                return View(new Location());
            }

            try
            {
                Location location = _provider.GetLocationById((int)Id);
                if (location != null)
                {
                    return View(location);
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
        public ActionResult AddEditLocation(Location location)
        {
            if (string.IsNullOrEmpty(location.Address) || location.Address.Length < 6)
            {
                return View(location);
            }
            try
            {
                if (location.Id != 0)
                {
                    _location.EditLocation(location.Id, location.Address);
                }
                else
                {
                    _location.AddLocation(location.Address);
                }
                return RedirectToAction("SearchLocations");
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View(location);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult DeleteLocation(int Id)
        {
            try
            {
                Location user = _provider.GetLocationById(Id);
                if (user != null)
                {
                    return View(user);
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

        [HttpPost, ActionName("DeleteLocation")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult DeleteConfirmed(int Id)
        {
            try
            {
                _location.DeleteLocationById(Id);
                return RedirectToAction("SearchLocations");
            }

            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View();
            }
        }
    }
}