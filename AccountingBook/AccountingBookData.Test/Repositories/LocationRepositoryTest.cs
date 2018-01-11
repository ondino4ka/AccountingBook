using AccountingBookData.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookData.Test.Repositories
{
    [TestClass]
    public class LocationRepositoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LocationRepository_PassNull_Exception()
        {
            LocationRepository locationRepository = new LocationRepository(null);
        }
    }
}
