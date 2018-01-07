using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Enums;
using AccountingBookWeb.BL.Attributes;
using AccountingBookWeb.Models;
using System;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        [AllowAnonymous]
        [OnlyAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [OnlyAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            var model = new LoginViewModel();
            try
            {
                var result = _loginService.Login(userName, password);
                if (result == LoginResult.NoError)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (result == LoginResult.EmptyCredentials)
                {
                    model.Message = "Check user name and password";
                }
                if (result == LoginResult.InvalidCredentials)
                {
                    model.Message = "The user is not valid";
                }
                return View(model);
            }
            catch (Exception exception)
            {
                model.Message = exception.Message;
                return View(model);
            }
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult Logout()
        {
            _loginService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}