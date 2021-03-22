namespace Catman.Education.Application.Models.Answered
{
    using Catman.Education.Application.Abstractions.Localization;
    using FluentValidation;

    public class AnsweredYesNoQuestion : AnsweredQuestion
    {
        public bool GivenAnswer { get; set; }
    }

    public class AnsweredYesNoQuestionValidator : AbstractValidator<AnsweredYesNoQuestion>
    {
        public AnsweredYesNoQuestionValidator(ILocalizer localizer)
        {
            Include(new AnsweredQuestionValidator(localizer));
        }
    }
}
