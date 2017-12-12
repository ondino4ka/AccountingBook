using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using AccountingBookBL.Providers;
using AccountingBookWeb.BL.Attributes;
using AccountingBookWeb.Models;
using AccountingBookCommon.Models;
using AccountingBookBL.Operations;

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
        [Admin]
        public ActionResult AddEditUser(UserViewModel userForm)
        {
            try
            {
                if (_userProvider.IsExistsUser(userForm.Id, userForm.Name))
                {
                    ModelState.AddModelError("Name", "A user with that name already exists");
                }
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View(userForm);
            }

            if (ModelState.IsValid)
            {
                User user = new User();
                user.Email = userForm.Email;
                user.Id = userForm.Id;
                user.Name = userForm.Name;
                user.Password = userForm.Password;
                user.Roles = userForm.Roles;
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
                    return RedirectToAction("ListUsers");
                }
                catch (Exception exception)
                {
                    ViewBag.Error = exception.Message;
                    return View(userForm);
                }
            }
            return View(userForm);
        }

        [HttpGet]
        [Admin]
        public ActionResult DeleteUser(int? Id)
        {
            if (!Id.HasValue)
            {
                return HttpNotFound();
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

        [HttpPost, ActionName("DeleteUser")]
        [Admin]
        public ActionResult DeleteConfirmed(int? Id)
        {
            if (!Id.HasValue)
            {
                return HttpNotFound();
            }
            try
            {
                _userOperation.DeleteUser((int)Id);
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