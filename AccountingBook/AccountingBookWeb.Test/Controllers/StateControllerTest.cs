using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AccountingBookWeb.Test.Controllers
{
    [TestClass]
    public class StateControllerTest
    {
        private StateController stateController;
        private  Mock<IStateProvider> stateProvider;
        private Mock<IStateService> stateService;

        [TestInitialize]
        public void TestInitialize()
        {
            stateProvider = new Mock<IStateProvider>();
            stateService = new Mock<IStateService>();
            stateController = new StateController(stateProvider.Object, stateService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StateController_PassNull_Exception()
        {
            StateController loginController = new StateController(null, null);
        }

        [TestMethod]
        public void StateController_ListStates_ListStateIsReturned()
        {
            IReadOnlyList<State> expectedResult = new List<State>()
            {
                new State() { Id = 1, StateName = "Working"},
                new State() { Id = 2, StateName = "Working"}
            };
            stateProvider
             .Setup(x => x.GetStates())
               .Returns(() =>
               {
                   return expectedResult;
               });

            ViewResult result = stateController.ListStates() as ViewResult;
            IReadOnlyList<State> actualResult = result.Model as IReadOnlyList<State>;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StateController_GetStates_NullModelIsReturned()
        {        
            stateProvider
             .Setup(x => x.GetStates())
               .Returns(() =>
               {
                   throw new Exception();
               });

            ViewResult result = stateController.ListStates() as ViewResult;
            IReadOnlyList<State> resultList = result.Model as IReadOnlyList<State>;

            Assert.IsNull(resultList);
        }


        [TestMethod]
        public void StateController_AddEditState_PassId_NotFoundResultIsReturned()
        {
            Type expectedResult = typeof(HttpNotFoundResult);

            stateProvider
             .Setup(x => x.GetStateById(It.IsAny<int>()))
             .Returns(() =>
             {
                 return null;
             });

            var actualResult = stateController.AddEditState(It.IsAny<int>());

            Assert.IsInstanceOfType(actualResult, expectedResult);
        }

        [TestMethod]
        public void StateController_AddEditState_PassNullId_NewStateIsReturned()
        {
            int? filter = null;
            int expectedResult = 0;

            ViewResult result = stateController.AddEditState(filter) as ViewResult;
            State location = result.Model as State;
            int actualResult = location.Id;

            Assert.IsTrue(actualResult == expectedResult);
        }

        [TestMethod]
        public void StateController_AddEditState_PassState_RedirectToListStatesView()
        {
            string expectedResult = "ListStates";
            stateService.Setup(x => x.EditState(It.IsAny<int>(), It.IsAny<string>()));

            RedirectToRouteResult result = stateController.AddEditState(
                new State() { Id = 1, StateName = "working" }
                )
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void StateController_AddEditState_PassWrongStateName_StateIsReturned()
        {
            State expectedResult = new State() { Id = 1, StateName = "work" };
            ViewResult result = stateController.AddEditState(
               expectedResult
                )
                as ViewResult;
            State actualResult = result.Model as State;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StateController_DeleteState_PassNonExistentId_NotFoundResultIsReturned()
        {
            int filter = -1;

            var actualResult = stateController.DeleteState(filter);
            Type expectedResult = typeof(HttpNotFoundResult);

            Assert.IsInstanceOfType(actualResult, expectedResult);
        }

        [TestMethod]
        public void LocationController_DeleteConfirmed_PassNonExistentId_NotFoundResultIsReturned()
        {
            string expectedResult = "ListStates";

            stateService
             .Setup(x => x.DeleteStateById(It.IsAny<int>()));

            var actualResult = stateController.DeleteConfirmed(It.IsAny<int>());

            RedirectToRouteResult result = stateController.DeleteConfirmed(
              It.IsAny<int>()
              )
              as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }
    }
}
