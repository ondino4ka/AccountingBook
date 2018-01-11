using AccountingBookBL.Providers.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Providers
{
    [TestClass]
    public class LocationProviderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LocationProvider_PassNull_Exception()
        {
            LocationProvider locationProvider = new LocationProvider(null);
        }
    }
}
