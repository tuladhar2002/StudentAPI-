using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentAPI_Main.CustomActionFilters
{
    public class ValidateModelAttribute: ActionFilterAttribute //implements
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
           if (context.ModelState.IsValid ==false)
            {
                context.Result = new BadRequestResult(); //default sends 400 bad request for failure of validation
            }
        }
    }
}
