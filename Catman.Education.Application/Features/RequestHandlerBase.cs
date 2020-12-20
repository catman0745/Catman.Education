namespace Catman.Education.Application.Features
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    internal abstract class RequestHandlerBase<TRequest>
        : IRequestHandler<TRequest, RequestResult>
        where TRequest : IRequest<RequestResult>
    {
        private readonly ILocalizer _localizer;

        protected RequestHandlerBase(ILocalizer localizer)
        {
            _localizer = localizer;
        }
        
        private static RequestResult Failure(string message, Error error) =>
            new RequestResult.Failure(message, error);
        
        protected static RequestResult Success(string message) =>
            new RequestResult.Success(message);

        protected static RequestResult NotFound(string message) =>
            Failure(message, new Error.NotFound());

        protected RequestResult ValidationError(string propertyName, string errorMessage) =>
            ValidationError(new Dictionary<string, string>() {[propertyName] = errorMessage});
        
        protected RequestResult ValidationError(IDictionary<string, string> errors) =>
            Failure(_localizer.ValidationError(), new Error.ValidationError(errors));

        protected RequestResult Unauthorized() =>
            Failure(_localizer.UnauthorizedError(), new Error.Unauthorized());

        protected RequestResult AccessViolation() =>
            Failure(_localizer.AccessViolationError(), new Error.AccessViolation());

        public Task<RequestResult> Handle(TRequest request, CancellationToken _) =>
            HandleAsync(request);

        protected abstract Task<RequestResult> HandleAsync(TRequest request);
    }
}
