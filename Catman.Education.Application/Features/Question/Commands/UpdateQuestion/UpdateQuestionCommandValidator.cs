namespace Catman.Education.Application.Features.Question.Commands.UpdateQuestion
{
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Abstractions;
    using FluentValidation;

    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.TestId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);

            RuleFor(command => command.Text).ValidQuestionText(localizer);
            RuleFor(command => command.Cost).ValidQuestionCost(localizer);
        }
    }
}
