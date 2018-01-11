using AccountingBookBL.Providers.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Providers
{
    [TestClass]
    public class UserProviderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UserProvider_PassNull_Exception()
        {
            UserProvider userProvider = new UserProvider(null);
        }
    }
}
