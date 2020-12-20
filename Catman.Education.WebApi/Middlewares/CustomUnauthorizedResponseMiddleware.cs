namespace Catman.Education.WebApi.Middlewares
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.WebApi.Responses;
    using Microsoft.AspNetCore.Http;

    internal class CustomUnauthorizedResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomUnauthorizedResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILocalizer localizer)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                var message = localizer.UnauthorizedError();
                var response = new Response(success: false, message);

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
