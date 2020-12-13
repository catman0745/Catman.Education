namespace Catman.Education.Application.PipelineBehaviors
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;

    internal class RoleValidationPipelineBehavior<TRequest, TResponse>
        : ValidationPipelineBehaviorBase<TRequest, TResponse>
    {
        private readonly IApplicationStore _store;
        protected readonly ILocalizer _localizer;

        public RoleValidationPipelineBehavior(IApplicationStore store, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _localizer = localizer;
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
                return RequestValidationResult.Invalid(_localizer.UnauthorizedError(), new Error.Unauthorized());
            }

            var requestor = await _store.Users.WithIdAsync(restrictedRequest.RequestorId);

            return requestor.Role == restrictedRequest.RequiredRequestorRole
                ? RequestValidationResult.Valid()
                : RequestValidationResult.Invalid(
                    _localizer.AccessViolationError(restrictedRequest.RequiredRequestorRole),
                    new Error.AccessViolation());
        }
    }
}
