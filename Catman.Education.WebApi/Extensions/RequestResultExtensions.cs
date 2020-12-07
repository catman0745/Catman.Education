namespace Catman.Education.WebApi.Extensions
{
    using System;
    using System.Runtime.CompilerServices;
    using Catman.Education.Application.Results;
    using Catman.Education.WebApi.Responses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    internal static class RequestResultExtensions
    {
        public static IActionResult ToActionResult(this RequestResult result, Func<IActionResult> onSuccess) =>
            result switch
            {
                RequestResult.Failure failure => ToErrorActionResult(result.Message, failure.Error),
                RequestResult.Success => onSuccess(),
                object unmatched => throw new SwitchExpressionException(unmatched)
            };

        public static IActionResult ToActionResult<TResource>(
            this ResourceRequestResult<TResource> resourceResult,
            Func<TResource, IActionResult> onSuccess) =>
            resourceResult switch
            {
                ResourceRequestResult<TResource>.Failure failure =>
                    ToErrorActionResult(resourceResult.Message, failure.Error),
                ResourceRequestResult<TResource>.Success success =>
                    onSuccess(success.Resource),
                object unmatched =>
                    throw new SwitchExpressionException(unmatched)
            };

        private static IActionResult ToErrorActionResult(string message, Error error) =>
            error switch
            {
                Error.NotFound =>
                    new NotFoundObjectResult(new Response(success: false, message)),
                Error.ValidationError validationError =>
                    new BadRequestObjectResult(new ValidationErrorResponse(message, validationError.Errors)),
                Error.Unauthorized =>
                    new UnauthorizedObjectResult(new Response(success: false, message)),
                Error.AccessViolation =>
                    ObjectResult(new Response(success: false, message), StatusCodes.Status403Forbidden),
                object unmatched =>
                    throw new SwitchExpressionException(unmatched)
            };

        private static IActionResult ObjectResult(object value, int statusCode) =>
            new ObjectResult(value) {StatusCode = statusCode};
    }
}
