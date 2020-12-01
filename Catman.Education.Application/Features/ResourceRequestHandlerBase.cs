namespace Catman.Education.Application.Features
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.RequestResults;
    using FluentValidation;
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

        protected static ResourceRequestResult<TResource> Incorrect(string propertyName, string errorMessage) =>
            Incorrect(new Dictionary<string, string>() {[propertyName] = errorMessage});
        
        protected static ResourceRequestResult<TResource> Incorrect(IDictionary<string, string> errors) =>
            Error(new Error.Incorrect(errors));

        protected static ResourceRequestResult<TResource> Unauthorized() =>
            Error(new Error.Unauthorized());

        protected static ResourceRequestResult<TResource> AccessViolation() =>
            Error(new Error.AccessViolation());

        /// <inheritdoc cref="EmptyValidator{TResourceRequest}"/>
        protected static IValidator<TResourceRequest> EmptyValidator => new EmptyValidator<TResourceRequest>();

        /// <summary> Request validator </summary>
        /// <remarks>
        ///     Enforces explicit validator declaration. Use <see cref="EmptyValidator"/> if validation is not required
        /// </remarks>
        protected abstract IValidator<TResourceRequest> Validator { get; }

        public async Task<ResourceRequestResult<TResource>> Handle(TResourceRequest request, CancellationToken _)
        {
            var validationErrors = Validator.Validate(request).Errors();
            if (validationErrors.Any())
            {
                return Incorrect(validationErrors);
            }
            
            return await HandleAsync(request);
        }

        protected abstract Task<ResourceRequestResult<TResource>> HandleAsync(TResourceRequest request);
    }
}
