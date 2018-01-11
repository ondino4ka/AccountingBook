using AccountingBookBL.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Services
{
    [TestClass]
    public class StateServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StateService_PassNull_Exception()
        {
            StateService locationService = new StateService(null);
        }
    }
}
