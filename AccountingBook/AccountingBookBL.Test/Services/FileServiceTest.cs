using AccountingBookBL.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingBookBL.Test.Services
{
    [TestClass]
    public class FileServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileService_PassNull_Exception()
        {
            FileService fileService = new FileService(null);
        }
    }
}
