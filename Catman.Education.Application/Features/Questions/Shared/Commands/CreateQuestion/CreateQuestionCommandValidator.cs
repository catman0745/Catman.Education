namespace Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class CreateQuestionCommandValidator<TQuestion> : AbstractValidator<CreateQuestionCommand<TQuestion>>
        where TQuestion : Question
    {
        public CreateQuestionCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.TestId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);
            
            RuleFor(command => command.Text).ValidQuestionText(localizer);
            RuleFor(command => command.Cost).ValidQuestionCost(localizer);
        }
    }
}
