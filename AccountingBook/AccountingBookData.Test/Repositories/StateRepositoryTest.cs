using AccountingBookData.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookData.Test.Repositories
{
    [TestClass]
    public class StateRepositoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StateRepository_PassNull_Exception()
        {
            StateRepository stateRepository = new StateRepository(null);
        }
    }
}
