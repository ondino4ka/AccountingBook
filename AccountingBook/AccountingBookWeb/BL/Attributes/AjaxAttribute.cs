using System.Reflection;
using System.Web.Mvc;

namespace AccountingBookWeb.BL.Attributes
{
    public class AjaxAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}