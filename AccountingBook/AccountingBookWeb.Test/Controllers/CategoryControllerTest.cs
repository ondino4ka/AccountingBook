using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;

namespace AccountingBookWeb.Test.Controllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        private CategoryController categoryController;
        private Mock<ICategoryProvider> categoryProvider;
        private Mock<ICategoryService> categoryService;

        [TestInitialize]
        public void TestInitialize()
        {
            categoryProvider = new Mock<ICategoryProvider>();
            categoryService = new Mock<ICategoryService>();
            categoryController = new CategoryController(categoryProvider.Object, categoryService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CategoryController_PassNull_Exception()
        {
            CategoryController categoryController = new CategoryController(null, null);
        }

        [TestMethod]
        public void CategoryController_AddEditCategory_PassNull_NewCategoryIsReturned()
        {
            int? filter = null;

            int expectedResult = 0;
            ViewResult result = categoryController.AddEditCategory(filter) as ViewResult;
            Category category = result.Model as Category;
            int actualResult = category.Id;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CategoryController_AddEditCategory_PassCategoryName_CategoryIsReturned()
        {
            string filterString50length = "123456789123456789123456789123456789123456789012341";
            Category expectedResult = new Category();
            expectedResult.Name = filterString50length;

            ViewResult result = categoryController.AddEditCategory(expectedResult) as ViewResult;
            Category actualResult = result.Model as Category;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CategoryController_DeleteCategory_PassNonExistentId_NotFoundResultIsReturned()
        {
            int filter = -1;

            var actualResult = categoryController.DeleteCategory(filter);
            Type expectedResult = typeof(HttpNotFoundResult);

            Assert.IsInstanceOfType(actualResult, expectedResult);
        }
    }
}