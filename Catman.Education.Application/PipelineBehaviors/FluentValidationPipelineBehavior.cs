namespace Catman.Education.Application.PipelineBehaviors
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Models.Result;
    using FluentValidation;
    using FluentValidation.Results;

    internal class FluentValidationPipelineBehavior<TRequest, TResponse>
        : ValidationPipelineBehaviorBase<TRequest, TResponse>
    {
        private static Error Incorrect(IEnumerable<ValidationFailure> validationFailures)
        {
            var validationErrors = validationFailures
                .GroupBy(failure => failure.PropertyName)
                .ToDictionary(propErrors => propErrors.Key, propErrors => propErrors.First().ErrorMessage);
            return new Error.ValidationError(validationErrors);
        }
        
        private readonly ICollection<IValidator<TRequest>> _validators;
        private readonly ILocalizer _localizer;

        public FluentValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators, ILocalizer localizer)
            : base(localizer)
        {
            _validators = validators.ToList();
            _localizer = localizer;
        }
        
        protected override bool ShouldBeValidated(TRequest request) => _validators.Any();

        protected override async Task<RequestValidationResult> ValidateAsync(TRequest request)
        {
            var validationFailures = new List<ValidationFailure>();
            foreach (var validator in _validators)
            {
                var failures = (await validator.ValidateAsync(request)).Errors;
                validationFailures.AddRange(failures.Where(failure => failure != null));
            }
            
            return validationFailures.Any()
                ? RequestValidationResult.Invalid(_localizer.ValidationError(), Incorrect(validationFailures))
                : RequestValidationResult.Valid();
        }
    }
}
