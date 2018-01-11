using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookWeb.Controllers;
using AccountingBookWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AccountingBookWeb.Test.Controllers
{
    [TestClass]
    public class SubjectControllerTest
    {
        private SubjectController subjectController;
        private Mock<ISubjectProvider> subjectProvider;
        private Mock<ISubjectService> subjectService;
        private Mock<IFileService> fileService;

        [TestInitialize]
        public void TestInitialize()
        {
            subjectProvider = new Mock<ISubjectProvider>();
            subjectService = new Mock<ISubjectService>();
            fileService = new Mock<IFileService>();
            subjectController = new SubjectController(
                subjectProvider.Object,
                subjectService.Object,
                fileService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubjectController_PassNull_Exception()
        {
            SubjectController subjectController = new SubjectController(null, null, null);
        }

        [TestMethod]
        public void SubjectController_GetSubjectsByCategoryId_ListCategoryIsReturned()
        {
            IReadOnlyList<SubjectDetails> expectedResult = new List<SubjectDetails>()
            {
                new SubjectDetails() { InventoryNumber = 1 },
                new SubjectDetails() { InventoryNumber = 2 }
            };
            subjectProvider
             .Setup(x => x.GetSubjectsByCategoryId(It.IsAny<int>()))
               .Returns(() =>
               {
                   return expectedResult;
               });

            PartialViewResult result = subjectController.GetSubjectsByCategoryId(It.IsAny<int>()) as PartialViewResult;
            IReadOnlyList<SubjectDetails> actualResult = result.Model as IReadOnlyList<SubjectDetails>;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SubjectController_AddSubject_SubjectViewModelIsReturned()
        {
            subjectProvider
            .Setup(x => x.IsExistsSubject(It.IsAny<int>()))
             .Returns(() =>
             {
                 return true;
             });

            SubjectViewModel expectedResult = new SubjectViewModel();
            ViewResult result = subjectController.AddSubject(expectedResult) as ViewResult;
            SubjectViewModel actualResult = result.Model as SubjectViewModel;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SubjectController_AddSubject_RedirectToSearchSubjectsView()
        {
            string expectedResult = "SearchSubjects";
            subjectService
                .Setup(x => x.AddSubject(new Subject()));

            RedirectToRouteResult result = subjectController.AddSubject(
               new SubjectViewModel())
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void SubjectController_EditSubjectInformation_PassId_NotFoundResultIsReturned()
        {
            Type expectedResult = typeof(HttpNotFoundResult);
            subjectProvider
             .Setup(x => x.GetSubjectByInventoryNumber(It.IsAny<int>()));

            ActionResult actualResult = subjectController.EditSubjectInformation(It.IsAny<int>());

            Assert.IsInstanceOfType(actualResult, expectedResult);
        }

        [TestMethod]
        public void SubjectController_EditSubjectInformation_RedirectToSearchSubjectsView()
        {
            string expectedResult = "SearchSubjects";
            subjectService
                .Setup(x => x.EditSubjectInformation(new Subject()));

            RedirectToRouteResult result = subjectController.EditSubjectInformation(
               new SubjectViewModel())
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void SubjectController_EditSubjectPhoto_PassId_NotFoundResultIsReturned()
        {
            Type expectedResult = typeof(HttpNotFoundResult);
            subjectProvider
             .Setup(x => x.GetSubjectInformationByInventoryNumber(It.IsAny<int>()));

            ActionResult actualResult = subjectController.EditSubjectPhoto(It.IsAny<int>());

            Assert.IsInstanceOfType(actualResult, expectedResult);
        }

        [TestMethod]
        public void SubjectController_EditSubjectPhoto_PassPhoto_RedirectToSearchSubjectsView()
        {
            string expectedResult = "SearchSubjects";

            Mock<HttpPostedFileBase> context = new Mock<HttpPostedFileBase>();

            subjectService
                .Setup(x => x.EditSubjectInformation(new Subject()));

            subjectService
              .Setup(x => x.EditSubjectPhoto(It.IsAny<int>(), It.IsAny<string>()));

            fileService
                  .Setup(x => x.UploadPhoto(It.IsAny<string>(), context.Object));


            RedirectToRouteResult result = subjectController.EditSubjectInformation(
               new SubjectViewModel())
                as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void SubjectController_DeleteSubject_PassNonExistentId_NotFoundResultIsReturned()
        {
            int filter = -1;

            var actualResult = subjectController.DeleteSubject(filter);
            Type expectedResult = typeof(HttpNotFoundResult);

            Assert.IsInstanceOfType(actualResult, expectedResult);
        }

        [TestMethod]
        public void SubjectController_DeleteConfirmed_PassNonExistentId_NotFoundResultIsReturned()
        {
            string expectedResult = "SearchSubjects";

            subjectService
             .Setup(x => x.DeleteSubjectByInventoryNumber(It.IsAny<int>()));

            var actualResult = subjectController.DeleteConfirmed(It.IsAny<int>(), It.IsAny<string>());

            RedirectToRouteResult result = subjectController.DeleteConfirmed(
              It.IsAny<int>(), It.IsAny<string>()
              )
              as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.RouteValues["action"]);
        }

        [TestMethod]
        public void SubjectController_GetImageSubject_PassName_ByteIsReturned()
        {
            string filter = "1.png";
            byte [] expectedResult = new byte[1];
            fileService
                .Setup(x => x.DownloadPhoto(filter))
                .Returns(() =>
                {
                    return expectedResult;
                });

            FileContentResult result = subjectController.GetImageSubject(filter) as FileContentResult;
            byte[] actualResult = result.FileContents;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
