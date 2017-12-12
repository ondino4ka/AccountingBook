using System;
using System.Web.Mvc;
using AccountingBookWeb.Models;
using AccountingBookWeb.BL.Attributes;
using AccountingBookBL.Services;
using AccountingBookCommon.Enums;
using AccountingBookBL.Providers;
using System.Collections.Generic;
using AccountingBookCommon.Models;
using System.Linq;
using StructureMap.Query;

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
        [BL.Attributes.Authorize]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [BL.Attributes.Authorize]
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
 
        public ActionResult Logout()
        {
            _loginService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}