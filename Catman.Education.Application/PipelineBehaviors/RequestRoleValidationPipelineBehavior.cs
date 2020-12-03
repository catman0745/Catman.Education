namespace Catman.Education.Application.PipelineBehaviors
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;

    internal class RequestRoleValidationPipelineBehavior<TRequest, TResponse>
        : RequestValidationPipelineBehaviorBase<TRequest, TResponse>
    {
        private readonly IApplicationStore _store;

        public RequestRoleValidationPipelineBehavior(IApplicationStore store)
        {
            _store = store;
        }

        protected override bool ShouldBeValidated(TRequest request) =>
            request switch
            {
                IRequestorRoleRestriction => true,
                _ => false
            };

        protected override async Task<RequestValidationResult> ValidateAsync(TRequest request)
        {
            var restrictedRequest = (IRequestorRoleRestriction) request;
            
            if (!await _store.Users.ExistsWithIdAsync(restrictedRequest.RequestorId))
            {
                return RequestValidationResult.Invalid(new Error.Unauthorized());
            }
            var requestor = await _store.Users.WithIdAsync(restrictedRequest.RequestorId);

            return requestor.Role == restrictedRequest.RequiredRequestorRole
                ? RequestValidationResult.Valid()
                : RequestValidationResult.Invalid(new Error.AccessViolation());
        }
    }
}
