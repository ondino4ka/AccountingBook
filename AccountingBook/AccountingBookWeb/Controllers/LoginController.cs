using System.Web.Mvc;
using AccountingBookBL.Services;
using AccountingBookCommon.Enums;
using AccountingBookWeb.Models;

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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var result = _loginService.Login(userName, password);
            if (result == LoginResult.NoError)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new LoginViewModel();
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
        public ActionResult Logout()
        {
            _loginService.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}