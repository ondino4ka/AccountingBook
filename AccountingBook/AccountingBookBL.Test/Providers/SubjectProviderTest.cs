using AccountingBookBL.Providers.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Providers
{
    [TestClass]
    public class SubjectProviderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubjectProvider_PassNull_Exception()
        {
            SubjectProvider subjectProvider = new SubjectProvider(null);
        }
    }
}
