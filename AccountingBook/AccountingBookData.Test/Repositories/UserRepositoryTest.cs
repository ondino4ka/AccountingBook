using AccountingBookData.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookData.Test.Repositories
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UserRepository_PassNull_Exception()
        {
            UserRepository userRepository = new UserRepository(null);
        }
    }
}
