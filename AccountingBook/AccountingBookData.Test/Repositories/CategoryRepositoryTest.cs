using AccountingBookData.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookData.Test.Repositories
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CategoryRepository_PassNull_Exception()
        {
            CategoryRepository categoryRepository = new CategoryRepository(null);
        }
    }
}
