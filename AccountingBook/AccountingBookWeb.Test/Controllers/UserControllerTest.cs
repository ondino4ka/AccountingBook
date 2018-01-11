using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookWeb.Controllers;
using AccountingBookWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;

namespace AccountingBookWeb.Test.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private UserController userController;
        private Mock<IUserProvider> userProvider;
        private Mock<IUserService> userService;

        [TestInitialize]
        public void TestInitialize()
        {
            userProvider = new Mock<IUserProvider>();
            userService = new Mock<IUserService>();
            userController = new UserController(
                userProvider.Object,
                userService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UserController_PassNull_Exception()
        {
            UserController userController = new UserController(null, null);
        }

        [TestMethod]
        public void UserController_AddUser_UserViewModelIsReturned()
        {
            UserViewModel expectedResult = new UserViewModel();
            userProvider
                .Setup(x => x.IsExistsUser(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(() =>
                {
                    return true;
                });

            ViewResult result = userController.AddEditUser(expectedResult)
                as ViewResult;

            UserViewModel actualResult = result.Model as UserViewModel;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void UserController_AddUser_RedirectToSearchSubjectsView()
        {
            string expectedResult = "SearchUsers";
            userService
                .Setup(x => x.AddUser(new User()));

            RedirectToRouteResult result = userController.AddEditUser(
               new UserViewModel())
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void UserController_EditUserInformation_NotFoundResultIsReturned()
        {
            Type expectedResult = typeof(HttpNotFoundResult);
            userProvider
             .Setup(x => x.GetUserById(It.IsAny<int>()));

            ActionResult actualResult = userController.EditUserInformation(It.IsAny<int>());

            Assert.IsInstanceOfType(actualResult, expectedResult);
        }

        [TestMethod]
        public void UserController_EditUserInformation_RedirectToSearchUsersView()
        {
            string expectedResult = "SearchUsers";
            userService
                .Setup(x => x.EditUserInformation(new User()));

            RedirectToRouteResult result = userController.EditUserInformation(
               new UserWithoutPassViewModel())
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void UserController_DeleteUser_PassNonExistentId_NotFoundResultIsReturned()
        {
            int filter = -1;

            var actualResult = userController.DeleteUser(filter);
            Type expectedResult = typeof(HttpNotFoundResult);

            Assert.IsInstanceOfType(actualResult, expectedResult);
        }

        [TestMethod]
        public void UserController_DeleteConfirmed_PassNonExistentId_NotFoundResultIsReturned()
        {
            string expectedResult = "SearchUsers";

            userService
             .Setup(x => x.DeleteUserById(It.IsAny<int>()));

            var actualResult = userController.DeleteConfirmed(It.IsAny<int>());

            RedirectToRouteResult result = userController.DeleteConfirmed(
              It.IsAny<int>())
              as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }
    }
}
