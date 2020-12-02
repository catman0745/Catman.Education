namespace Catman.Education.Application.PipelineBehaviors
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.RequestResults;
    using FluentValidation;
    using MediatR;

    internal class RequestValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : RequestResult
    {
        private static RequestResult Failed(IDictionary<string, string> validationErrors) =>
            new RequestResult.Failure(new Error.Incorrect(validationErrors));
        
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken _,
            RequestHandlerDelegate<TResponse> next)
        {
            var validationFailures = _validators.ValidationFailures(request).ToList();
            if (!validationFailures.Any())
            {
                return await next();
            }

            return (TResponse) Failed(validationFailures.ValidationErrors());
        }
    }
}
