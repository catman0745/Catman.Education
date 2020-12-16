namespace Catman.Education.Application.Features
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    internal abstract class ResourceRequestHandlerBase<TResourceRequest, TResource>
        : IRequestHandler<TResourceRequest, ResourceRequestResult<TResource>>
        where TResourceRequest : IRequest<ResourceRequestResult<TResource>>
    {
        private readonly ILocalizer _localizer;

        protected ResourceRequestHandlerBase(ILocalizer localizer)
        {
            _localizer = localizer;
        }
        
        private static ResourceRequestResult<TResource> Failure(string message, Error error) =>
            new ResourceRequestResult<TResource>.Failure(message, error);
        
        protected static ResourceRequestResult<TResource> Success(string message, TResource resource) =>
            new ResourceRequestResult<TResource>.Success(message, resource);
        
        protected static ResourceRequestResult<TResource> NotFound(string message) =>
            Failure(message, new Error.NotFound());

        protected ResourceRequestResult<TResource> TestRetake(Guid studentId, Guid testId) =>
            Failure(_localizer.TestRetake(studentId, testId), new Error.TestRetake());

        protected ResourceRequestResult<TResource> ValidationError(string propertyName, string errorMessage) =>
            ValidationError(new Dictionary<string, string>() {[propertyName] = errorMessage});
        
        protected ResourceRequestResult<TResource> ValidationError(IDictionary<string, string> errors) =>
            Failure(_localizer.ValidationError(), new Error.ValidationError(errors));

        protected ResourceRequestResult<TResource> Unauthorized() =>
            Failure(_localizer.UnauthorizedError(), new Error.Unauthorized());

        protected ResourceRequestResult<TResource> AccessViolation() =>
            Failure(_localizer.AccessViolationError(), new Error.AccessViolation());

        public Task<ResourceRequestResult<TResource>> Handle(TResourceRequest request, CancellationToken _) =>
            HandleAsync(request);

        protected abstract Task<ResourceRequestResult<TResource>> HandleAsync(TResourceRequest request);
    }
}
