namespace Catman.Education.Application.PipelineBehaviors
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Results;
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

        public FluentValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators.ToList();
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
                ? RequestValidationResult.Invalid("Validation errors occurred", Incorrect(validationFailures))
                : RequestValidationResult.Valid();
        }
    }
}
