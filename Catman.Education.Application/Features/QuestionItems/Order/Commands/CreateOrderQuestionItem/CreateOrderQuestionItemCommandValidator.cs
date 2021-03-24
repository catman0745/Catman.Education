namespace Catman.Education.Application.Features.QuestionItems.Order.Commands.CreateOrderQuestionItem
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.CreateQuestionItem;
    using FluentValidation;

    public class CreateOrderQuestionItemCommandValidator : AbstractValidator<CreateOrderQuestionItemCommand>
    {
        public CreateOrderQuestionItemCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionItemCommandValidator<OrderQuestionItem>(localizer));
        }
    }
}
