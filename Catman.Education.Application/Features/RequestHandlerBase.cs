namespace Catman.Education.Application.Features
{
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Models.Result;
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

        public Task<RequestResult> Handle(TRequest request, CancellationToken _) =>
            HandleAsync(request);

        protected abstract Task<RequestResult> HandleAsync(TRequest request);
    }
}
