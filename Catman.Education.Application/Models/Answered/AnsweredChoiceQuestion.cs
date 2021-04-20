namespace Catman.Education.Application.Models.Answered
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class AnsweredChoiceQuestion : AnsweredQuestion
    {
        public ICollection<Guid> SelectedAnswerOptionIds { get; set; }
    }

    public class AnsweredChoiceQuestionValidator : AbstractValidator<AnsweredChoiceQuestion>
    {
        public AnsweredChoiceQuestionValidator(ILocalizer localizer)
        {
            Include(new AnsweredQuestionValidator(localizer));

            RuleForEach(question => question.SelectedAnswerOptionIds).NotEmpty(localizer);
        }
    }
}
