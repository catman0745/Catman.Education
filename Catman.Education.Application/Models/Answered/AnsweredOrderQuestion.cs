namespace Catman.Education.Application.Models.Answered
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class AnsweredOrderQuestion : AnsweredQuestion
    {
        public ICollection<Guid> OrderedItemIds { get; set; }
    }

    public class AnsweredOrderQuestionValidator : AbstractValidator<AnsweredOrderQuestion>
    {
        public AnsweredOrderQuestionValidator(ILocalizer localizer)
        {
            Include(new AnsweredQuestionValidator(localizer));

            RuleFor(question => question.OrderedItemIds).NotNull(localizer);
            RuleForEach(question => question.OrderedItemIds).NotEmpty(localizer);
        }
    }
}
