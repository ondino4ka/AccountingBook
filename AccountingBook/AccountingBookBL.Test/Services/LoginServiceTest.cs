using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountingBookBL.Services.Implementations;

namespace AccountingBookBL.Test.Services
{
    [TestClass]
    public class LoginServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoginService_PassNull_Exception()
        {
            LoginService locationService = new LoginService(null, null);
        }
    }
}
