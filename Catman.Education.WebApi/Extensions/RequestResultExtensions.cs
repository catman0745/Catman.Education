namespace Catman.Education.WebApi.Extensions
{
    using System;
    using System.Runtime.CompilerServices;
    using Catman.Education.Application.RequestResults;
    using Microsoft.AspNetCore.Mvc;

    internal static class RequestResultExtensions
    {
        public static IActionResult ToActionResult(this RequestResult result, Func<IActionResult> onSuccess) =>
            result switch
            {
                RequestResult.Failure failure => ToErrorActionResult(failure.Error),
                RequestResult.Success => onSuccess(),
                object unmatched => throw new SwitchExpressionException(unmatched)
            };

        public static IActionResult ToActionResult<TResource>(
            this ResourceRequestResult<TResource> resourceResult,
            Func<TResource, IActionResult> onSuccess) =>
            resourceResult switch
            {
                ResourceRequestResult<TResource>.Failure failure => ToErrorActionResult(failure.Error),
                ResourceRequestResult<TResource>.Success success => onSuccess(success.Resource),
                object unmatched => throw new SwitchExpressionException(unmatched)
            };

        private static IActionResult ToErrorActionResult(Error error) =>
            error switch
            {
                Error.NotFound => new NotFoundResult(),
                Error.Duplicate duplicateError => new BadRequestObjectResult(duplicateError.Message),
                Error.Incorrect incorrectError => new BadRequestObjectResult(incorrectError.Message),
                Error.Unauthorized => new UnauthorizedResult(),
                Error.AccessViolation => new ForbidResult(),
                object unmatched => throw new SwitchExpressionException(unmatched)
            };
    }
}
