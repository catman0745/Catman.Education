namespace Catman.Education.WebApi.Filters
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    internal class ValidationFilter : IAsyncActionFilter
    {
        private readonly ILocalizer _localizer;

        public ValidationFilter(ILocalizer localizer)
        {
            _localizer = localizer;
        }
        
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
                
                var response = new ValidationErrorResponse(_localizer.ValidationError(), errors);
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
