using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ContractManager.Controllers.Base
{
    public class RequireRequestValuesAttribute : ActionMethodSelectorAttribute
    {
        public RequireRequestValuesAttribute(params string[] valuesName)
        {
            ValuesName = valuesName;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return ValuesName.All(value => controllerContext.HttpContext.Request[value] != null);
        }
        
        public string[] ValuesName { get; private set; }
    }
}