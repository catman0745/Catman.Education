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
        private static RequestResult Error(Error error) =>
            new RequestResult.Failure(error);
        
        protected static RequestResult Success() =>
            new RequestResult.Success();
        
        protected static RequestResult NotFound() =>
            Error(new Error.NotFound());
        
        protected static RequestResult Duplicate(string message) =>
            Error(new Error.Duplicate(message));

        protected static RequestResult Incorrect(string propertyName, string errorMessage) =>
            Incorrect(new Dictionary<string, string>() {[propertyName] = errorMessage});
        
        protected static RequestResult Incorrect(IDictionary<string, string> errors) =>
            Error(new Error.Incorrect(errors));

        protected static RequestResult Unauthorized() =>
            Error(new Error.Unauthorized());

        protected static RequestResult AccessViolation() =>
            Error(new Error.AccessViolation());

        public Task<RequestResult> Handle(TRequest request, CancellationToken _) =>
            HandleAsync(request);

        protected abstract Task<RequestResult> HandleAsync(TRequest request);
    }
}
