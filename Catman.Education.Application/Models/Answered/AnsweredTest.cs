namespace Catman.Education.Application.Models.Answered
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class AnsweredTest
    {
        public Guid TestId { get; set; }
        
        public ICollection<AnsweredQuestion> AnsweredQuestions { get; set; }
    }

    public class AnsweredTestValidator : AbstractValidator<AnsweredTest>
    {
        public AnsweredTestValidator(ILocalizer localizer)
        {
            RuleFor(test => test.TestId).NotEmpty(localizer);
            RuleFor(test => test.AnsweredQuestions).NotEmpty(localizer);

            RuleForEach(test => test.AnsweredQuestions.OfType<AnsweredChoiceQuestion>())
                .SetValidator(new AnsweredChoiceQuestionValidator(localizer));
        }
    }
}
