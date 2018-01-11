using AccountingBookData.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookData.Test.Repositories
{
    [TestClass]
    public class SubjectRepositoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubjectRepository_PassNull_Exception()
        {
            SubjectRepository subjectRepository = new SubjectRepository(null);
        }
    }
}
