namespace Catman.Education.Application.Features
{
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.RequestResults;
    using MediatR;

    internal abstract class ResourceRequestHandlerBase<TResourceRequest, TResource>
        : IRequestHandler<TResourceRequest, ResourceRequestResult<TResource>>
        where TResourceRequest : IRequest<ResourceRequestResult<TResource>>
    {
        private static ResourceRequestResult<TResource> Error(Error error) =>
            new ResourceRequestResult<TResource>.Failure(error);
        
        protected static ResourceRequestResult<TResource> Success(TResource resource) =>
            new ResourceRequestResult<TResource>.Success(resource);
        
        protected static ResourceRequestResult<TResource> NotFound() =>
            Error(new Error.NotFound());
        
        protected static ResourceRequestResult<TResource> Duplicate(string message) =>
            Error(new Error.Duplicate(message));
        
        public Task<ResourceRequestResult<TResource>> Handle(TResourceRequest request, CancellationToken _)
        {
            return HandleAsync(request);
        }

        protected abstract Task<ResourceRequestResult<TResource>> HandleAsync(TResourceRequest request);
    }
}
