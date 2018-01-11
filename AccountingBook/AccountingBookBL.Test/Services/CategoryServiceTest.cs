using AccountingBookBL.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Services
{
    [TestClass]
    public class CategoryServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CategoryService_PassNull_Exception()
        {
            CategoryService categoryService = new CategoryService(null);
        }
    }
}
