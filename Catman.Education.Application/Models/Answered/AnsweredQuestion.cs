namespace Catman.Education.Application.Models.Answered
{
    using System;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public abstract class AnsweredQuestion
    {
        public Guid QuestionId { get; set; }
    }

    public class AnsweredQuestionValidator : AbstractValidator<AnsweredQuestion>
    {
        public AnsweredQuestionValidator(ILocalizer localizer)
        {
            RuleFor(question => question.QuestionId).NotEmpty(localizer);
        }
    }
}
