using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_Learning.Presentation.ActionFilter;

public class ValidationFilterAttribute : IActionFilter
{
    public ValidationFilterAttribute()
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Get action and controller names from the route data
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];

        // Get the action parameter whose value contains "Dto"
        var param = context.ActionArguments
            .SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

        // Check if the parameter is null
        if (param is null)
        {
            // If null, return a BadRequestObjectResult with error information
            context.Result = new BadRequestObjectResult(
                $"Object is null. Controller: {controller}, action: {action}");
            return;
        }

        // Check if the model state is valid
        if (!context.ModelState.IsValid)
        {
            // If the model state is invalid, return an UnprocessableEntityObjectResult
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }



}