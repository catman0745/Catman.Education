namespace Catman.Education.Application.Models.Answered
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;
    
    public class AnsweredValueQuestion : AnsweredQuestion
    {
        public string GivenAnswer { get; set; }
    }

    public class AnsweredValueQuestionValidator : AbstractValidator<AnsweredValueQuestion>
    {
        public AnsweredValueQuestionValidator(ILocalizer localizer)
        {
            Include(new AnsweredQuestionValidator(localizer));

            RuleFor(question => question.GivenAnswer).ValidQuestionAnswer(localizer);
        }
    }
}
