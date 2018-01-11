using AccountingBookWeb.BL.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountingBookWeb.Test.Attributes
{
    [TestClass]
    public class RequiredArrayAttributeTest
    {
        [TestMethod]
        public void RequiredArrayAttribute_IsValid_PassList_BoolIsReturned()
        {
            bool expectedResult = true;

            int[] list = new int[1];
            RequiredArrayAttribute reqArrAttribute = new RequiredArrayAttribute();
            
            bool actualResult = reqArrAttribute.IsValid(list);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
