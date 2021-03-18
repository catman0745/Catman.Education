namespace Catman.Education.Application.Models.Answered
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class AnsweredMultipleChoiceQuestion : AnsweredQuestion
    {
        public ICollection<Guid> SelectedAnswerOptionIds { get; set; }
    }

    public class AnsweredMultipleChoiceQuestionValidator : AbstractValidator<AnsweredMultipleChoiceQuestion>
    {
        public AnsweredMultipleChoiceQuestionValidator(ILocalizer localizer)
        {
            Include(new AnsweredQuestionValidator(localizer));

            RuleFor(question => question.SelectedAnswerOptionIds).NotEmpty(localizer);
            RuleForEach(question => question.SelectedAnswerOptionIds).NotEmpty(localizer);
        }
    }
}
