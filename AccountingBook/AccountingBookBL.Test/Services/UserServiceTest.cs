using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountingBookBL.Services.Implementations;

namespace AccountingBookBL.Test.Services
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UserService_PassNull_Exception()
        {
            UserService locationService = new UserService(null, null);
        }
    }
}
