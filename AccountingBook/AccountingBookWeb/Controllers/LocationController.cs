using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookWeb.BL.Attributes;
using log4net;
using System;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class LocationController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger("LocationController");
        private readonly ILocationProvider _locationProvider;
        private readonly ILocationService _locationService;
        public LocationController(ILocationProvider locationProvider, ILocationService locationService)
        {
            if (locationProvider == null || locationProvider == null)
            {
                Log.Error("locationProvider or locationService is null");
                throw new ArgumentNullException();
            }
            _locationProvider = locationProvider;
            _locationService = locationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
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
                return Json(_locationProvider.GetLocations(), JsonRequestBehavior.AllowGet);
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
                return PartialView("Locations", _locationProvider.GetLocationsByAddress(address));
            }
            catch (Exception)
            {
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
                Location location = _locationProvider.GetLocationById((int)Id);
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
            if (string.IsNullOrEmpty(location.Address) || location.Address.Length < 6 || location.Address.Length > 100)
            {
                return View(location);
            }
            try
            {
                if (location.Id != 0)
                {
                    _locationService.EditLocationById(location.Id, location.Address);
                }
                else
                {
                    _locationService.AddLocation(location.Address);
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
                Location user = _locationProvider.GetLocationById(Id);
                if (user != null)
                {
                    return View(user);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
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
                _locationService.DeleteLocationById(Id);
                return RedirectToAction("SearchLocations");
            }

            catch (Exception)
            {
                return View();
            }
        }
    }
}