using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookWeb.BL.Attributes;
using AccountingBookWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AccountingBookWeb.Test.Attributes
{
    [TestClass]
    public class AjaxAttributeTest
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
        public void AjaxAttribute_IsValidForRequest_PassNull_BoolIsReturned()
        {
            bool expectedResult = true;

            Mock<HttpRequestBase> request = new Mock<HttpRequestBase>();

            request.SetupGet(x => x.Headers).Returns(
                new System.Net.WebHeaderCollection {
        {"X-Requested-With", "XMLHttpRequest"}
                });

            MethodInfo mInfo = typeof(CategoryController).GetMethod("CategoriesBar",
             new Type[] { });

            Mock<HttpContextBase> context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);

            AjaxAttribute ajaxAttr = new AjaxAttribute();
            CategoryController controller = new CategoryController(categoryProvider.Object, categoryService.Object);
       
            bool actualResult = ajaxAttr.IsValidForRequest(
                new ControllerContext(context.Object, new RouteData(), controller),
                mInfo);
            Assert.IsTrue(expectedResult = actualResult);
        }
    }
}
