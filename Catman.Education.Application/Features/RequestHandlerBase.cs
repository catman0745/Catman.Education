namespace Catman.Education.Application.Features
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Results;
    using MediatR;

    internal abstract class RequestHandlerBase<TRequest>
        : IRequestHandler<TRequest, RequestResult>
        where TRequest : IRequest<RequestResult>
    {
        private static RequestResult Failure(string message, Error error) =>
            new RequestResult.Failure(message, error);
        
        protected static RequestResult Success(string message) =>
            new RequestResult.Success(message);

        protected static RequestResult NotFound(string message) =>
            Failure(message, new Error.NotFound());

        protected static RequestResult ValidationError(string propertyName, string errorMessage) =>
            ValidationError(new Dictionary<string, string>() {[propertyName] = errorMessage});
        
        protected static RequestResult ValidationError(IDictionary<string, string> errors) =>
            Failure("Validation errors occured", new Error.ValidationError(errors));

        protected static RequestResult Unauthorized() =>
            Failure("User must be authorized", new Error.Unauthorized());

        protected static RequestResult AccessViolation() =>
            Failure("Access violation", new Error.AccessViolation());

        public Task<RequestResult> Handle(TRequest request, CancellationToken _) =>
            HandleAsync(request);

        protected abstract Task<RequestResult> HandleAsync(TRequest request);
    }
}
