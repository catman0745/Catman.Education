namespace Catman.Education.Application.Features.QuestionItems.Shared.Commands.UpdateQuestionItem
{
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Extensions.Validation;
    using FluentValidation;

    public class UpdateQuestionItemCommandValidator : AbstractValidator<UpdateQuestionItemCommand>
    {
        public UpdateQuestionItemCommandValidator(ILocalizer localizer)
        {
            RuleFor(command => command.Id).NotEmpty(localizer);
            RuleFor(command => command.QuestionId).NotEmpty(localizer);
            RuleFor(command => command.RequestorId).NotEmpty(localizer);

            RuleFor(command => command.Text).ValidQuestionItemText(localizer);
        }
    }
}
