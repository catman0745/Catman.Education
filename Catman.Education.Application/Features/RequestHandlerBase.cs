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

        /// <inheritdoc cref="EmptyValidator"/>
        protected static IValidator<TRequest> EmptyValidator => new EmptyValidator<TRequest>();

        /// <summary> Request validator </summary>
        /// <remarks>
        ///     Enforces explicit validator declaration. Use <see cref="EmptyValidator"/> if validation is not required
        /// </remarks>
        protected abstract IValidator<TRequest> Validator { get; }

        public async Task<RequestResult> Handle(TRequest request, CancellationToken _)
        {
            var validationErrors = Validator.Validate(request).Errors();
            if (validationErrors.Any())
            {
                return Incorrect(validationErrors);
            }
            
            return await HandleAsync(request);
        }

        protected abstract Task<RequestResult> HandleAsync(TRequest request);
    }
}
