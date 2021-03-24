namespace Catman.Education.Application.Features.QuestionItems.Order.Commands.UpdateOrderQuestionItem
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.UpdateQuestionItem;
    using FluentValidation;

    public class UpdateOrderQuestionItemCommandValidator : AbstractValidator<UpdateOrderQuestionItemCommand>
    {
        public UpdateOrderQuestionItemCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionItemCommandValidator(localizer));
        }
    }
}
