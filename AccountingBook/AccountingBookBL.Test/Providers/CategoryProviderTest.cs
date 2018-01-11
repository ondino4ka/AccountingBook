using AccountingBookBL.Providers.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Providers
{
    [TestClass]
    public class CategoryProviderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CategoryProvider_PassNull_Exception()
        {
            CategoryProvider categoryProvider = new CategoryProvider(null);
        }
    }
}
