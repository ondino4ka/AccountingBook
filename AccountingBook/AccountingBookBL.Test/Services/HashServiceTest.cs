using AccountingBookBL.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Services
{
    [TestClass]
    public class HashServiceTest
    {
        [TestMethod]
        public void HashService_GetHash_PassPassword_HashIsReturned()
        {
            string filter = "123456";
            string expectedResult = "7C4A8D09CA3762AF61E59520943DC26494F8941B";
            HashService hashService = new HashService();
            string actualResult = hashService.GetHash(filter);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashService_GetHash_PassEmpty_Exception()
        {
            string filter = "";         
            HashService hashService = new HashService();
            string actualResult = hashService.GetHash(filter);
        }
    }
}
