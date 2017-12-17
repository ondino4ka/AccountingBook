using AccountingBookBL.Operations;
using AccountingBookBL.Providers;
using AccountingBookCommon.Models;
using AccountingBookWeb.BL.Attributes;
using AccountingBookWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserProvider _userProvider;
        private readonly IUserOperation _userOperation;
        public UserController(IUserProvider userProvider, IUserOperation userOperation)
        {
            _userProvider = userProvider;
            _userOperation = userOperation;
        }

        [Admin]
        public ActionResult SearchUsers()
        {
            return View();
        }

        [Ajax]
        [Admin]
        public PartialViewResult GetUsersByName(string userName)
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            try
            {
                userList.AddRange(_userProvider.GetUsersByName(userName).Select(x => new UserViewModel(x)).ToList());
                return PartialView("Users", userList);
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return PartialView("Users");
            }
        }

        [HttpGet]
        [Admin]
        public ActionResult AddEditUser(int? Id)
        {
            if (!Id.HasValue)
            {
                return View(new UserViewModel());
            }

            try
            {
                User user = _userProvider.GetUserById((int)Id);
                if (user != null)
                {
                    return View(new UserViewModel(user));
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
        [Admin]
        public ActionResult AddEditUser(UserViewModel userViewModel)
        {
            try
            {
                if (_userProvider.IsExistsUser(userViewModel.Id, userViewModel.Name))
                {
                    ModelState.AddModelError("Name", "A user with that name already exists");
                }
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View(userViewModel);
            }

            if (ModelState.IsValid)
            {
                User user = new User();
                user.Email = userViewModel.Email;
                user.Id = userViewModel.Id;
                user.Name = userViewModel.Name;
                user.Password = userViewModel.Password;
                user.Roles = userViewModel.Roles;
                try
                {
                    if (user.Id != 0)
                    {
                        _userOperation.EditUser(user);
                    }
                    else
                    {
                        _userOperation.AddUser(user);
                    }
                    return RedirectToAction("SearchUsers");
                }
                catch (Exception exception)
                {
                    ViewBag.Error = exception.Message;
                    return View(userViewModel);
                }
            }
            return View(userViewModel);
        }

        [HttpGet]
        [Admin]
        public ActionResult DeleteUser(int Id)
        {
            try
            {
                User user = _userProvider.GetUserById(Id);
                if (user != null)
                {
                    return View(new UserViewModel(user));
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

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        [Admin]
        public ActionResult DeleteConfirmed(int Id)
        {
            try
            {
                _userOperation.DeleteUserById(Id);
                return RedirectToAction("ListUsers");
            }

            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View();
            }
        }

        [Ajax]
        [Admin]
        public JsonResult GetRoles()
        {
            try
            {
                return Json(_userProvider.GetRoles(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}