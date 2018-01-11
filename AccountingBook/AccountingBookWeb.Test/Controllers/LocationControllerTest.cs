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
    public class LocationControllerTest
    {
        private LocationController locationController;
        private Mock<ILocationProvider> locationProvider;
        private Mock<ILocationService> locationService;

        [TestInitialize]
        public void TestInitialize()
        {
            locationProvider = new Mock<ILocationProvider>();
            locationService = new Mock<ILocationService>();
            locationController = new LocationController(locationProvider.Object, locationService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LocationController_PassNull_Exception()
        {
            LocationController locationController = new LocationController(null, null);
        }

        [TestMethod]
        public void LocationController_GetLocationsByAddress_PassAddress_NewLocationsIsReturned()
        {
            locationProvider
                .Setup(x => x.GetLocationsByAddress(It.IsAny<string>()))
                .Returns(() => 
            {
                throw new Exception();
            });

            IReadOnlyList<Location> actualResult = locationController.GetLocationsByAddress("mogilev").Model as IReadOnlyList<Location>;
            Assert.IsNull(actualResult);
        }

        [TestMethod]
        public void LocationController_AddEditLocation_PassId_NotFoundResultIsReturned()
        {
            Type expectedResult = typeof(HttpNotFoundResult);

            locationProvider
             .Setup(x => x.GetLocationById(It.IsAny<int>()))
             .Returns(() =>
             {
                 return null;
             });

            var actualResult = locationController.AddEditLocation(It.IsAny<int>());

            Assert.IsInstanceOfType(actualResult, expectedResult);           
        }


        [TestMethod]
        public void LocationController_AddEditLocation_PassNullId_NewLocationIsReturned()
        {
            int? filter = null;
            int expectedResult = 0;

            ViewResult result = locationController.AddEditLocation(filter) as ViewResult;
            Location location = result.Model as Location;
            int actualResult = location.Id;

            Assert.IsTrue(actualResult ==  expectedResult);
        }

        [TestMethod]
        public void LocationController_AddEditLocation_PassAddress_RedirectToSearchLocationsView()
        {
            string expectedResult = "SearchLocations";
            locationService.Setup(x => x.EditLocationById(It.IsAny<int>(), It.IsAny<string>()));

            RedirectToRouteResult result = locationController.AddEditLocation(
                new Location() {Id = 1, Address = "Mogilev City" }
                )
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void LocationController_AddEditLocation_PassWrongAddress_LocationIsReturned()
        {
            locationService.Setup(x => x.EditLocationById(It.IsAny<int>(), It.IsAny<string>()));

            Location expectedResult = new Location() { Id = 1, Address = "Mog" };
            ViewResult result = locationController.AddEditLocation(
               expectedResult
                )
                as ViewResult;
            Location actualResult = result.Model as Location;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LocationController_DeleteLocation_PassNonExistentId_NotFoundResultIsReturned()
        {
            int filter = -1;

            var actualResult = locationController.DeleteLocation(filter);
            Type expectedResult = typeof(HttpNotFoundResult);

            Assert.IsInstanceOfType(actualResult, expectedResult);
        }

        [TestMethod]
        public void LocationController_DeleteConfirmed_PassNonExistentId_NotFoundResultIsReturned()
        {
            string expectedResult = "SearchLocations";

            locationService
             .Setup(x => x.DeleteLocationById(It.IsAny<int>()));

            var actualResult = locationController.DeleteConfirmed(It.IsAny<int>());
        
            RedirectToRouteResult result = locationController.DeleteConfirmed(
              It.IsAny<int>()
              )
              as RedirectToRouteResult;
         
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }       
    }
}
