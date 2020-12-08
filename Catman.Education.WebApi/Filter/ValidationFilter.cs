namespace Catman.Education.WebApi.Filter
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.WebApi.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    internal class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
            }
            else
            {
                var errors = context.ModelState
                    .Where(kvp => kvp.Value.Errors.Any())
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.First().ErrorMessage);
                
                var response = new ValidationErrorResponse("Validation errors occurred", errors);
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
