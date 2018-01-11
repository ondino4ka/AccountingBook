using AccountingBookBL.Providers.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Providers
{
    [TestClass]
    public class StateProviderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StateProvider_PassNull_Exception()
        {
            StateProvider stateProvider = new StateProvider(null);
        }
    }
}
