using AccountingBookBL.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Services
{
    [TestClass]
    public class LocationServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LocationService_PassNull_Exception()
        {
            LocationService locationService = new LocationService(null);
        }
    }
}
