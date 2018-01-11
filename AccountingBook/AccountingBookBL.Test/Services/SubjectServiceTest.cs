using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountingBookBL.Services.Implementations;

namespace AccountingBookBL.Test.Services
{
    [TestClass]
    public class SubjectServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubjectService_PassNull_Exception()
        {
            SubjectService locationService = new SubjectService(null);
        }
    }
}
