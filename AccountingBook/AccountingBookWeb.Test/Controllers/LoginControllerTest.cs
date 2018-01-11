using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Enums;
using AccountingBookWeb.Controllers;
using AccountingBookWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;

namespace AccountingBookWeb.Test.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {
        private LoginController loginController;
        private Mock<ILoginService> loginService;

        [TestInitialize]
        public void TestInitialize()
        {
            loginService = new Mock<ILoginService>();
            loginController = new LoginController(loginService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoginController_PassNull_Exception()
        {
            LoginController loginController = new LoginController(null);
        }

        [TestMethod]
        public void LoginController_Login_PassValidNameAndPassword_RedirectToIndexView()
        {
            string expectedResult = "Index";
            loginService
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                  .Returns(() =>
                  {
                      return LoginResult.NoError;
                  });

            RedirectToRouteResult result = loginController.Login(
               It.IsAny<string>(), It.IsAny<string>())
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void LoginController_Login_PassNameAndPassword_RedirectToIndexView()
        {
            string expectedResult = "Index";
            loginService
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                  .Returns(() =>
                  {
                      return LoginResult.NoError;
                  });

            RedirectToRouteResult result = loginController.Login(
               It.IsAny<string>(), It.IsAny<string>())
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void LocationController_Login_PassEmptyNameAndPassword_MessageIsReturned()
        {
            string expectedResult = "Check user name and password";

            loginService
               .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                 .Returns(() =>
                 {
                     return LoginResult.EmptyCredentials;
                 });

            ViewResult result = loginController.Login(It.IsAny<string>(), It.IsAny<string>())
               as ViewResult;
            LoginViewModel loginViewModel = result.Model as LoginViewModel;

            string actualResult = loginViewModel.Message;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LocationController_Login_PassWrongNameAndPassword_MessageIsReturned()
        {
            string expectedResult = "The user is not valid";

            loginService
               .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                 .Returns(() =>
                 {
                     return LoginResult.InvalidCredentials;
                 });

            ViewResult result = loginController.Login(It.IsAny<string>(), It.IsAny<string>())
               as ViewResult;
            LoginViewModel loginViewModel = result.Model as LoginViewModel;

            string actualResult = loginViewModel.Message;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LoginController_Logout_PassValidNameAndPassword_RedirectToIndexView()
        {
            string expectedResult = "Index";
            loginService.Setup(x => x.Logout());

            RedirectToRouteResult result = loginController.Logout()
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }
    }
}
