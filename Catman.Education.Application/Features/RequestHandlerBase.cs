namespace Catman.Education.Application.Features
{
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.RequestResults;
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

        protected static RequestResult Incorrect(string message) =>
            Error(new Error.Incorrect(message));

        protected static RequestResult Unauthorized() =>
            Error(new Error.Unauthorized());

        protected static RequestResult AccessViolation() =>
            Error(new Error.AccessViolation());
        
        public Task<RequestResult> Handle(TRequest request, CancellationToken _)
        {
            return HandleAsync(request);
        }

        protected abstract Task<RequestResult> HandleAsync(TRequest request);
    }
}
