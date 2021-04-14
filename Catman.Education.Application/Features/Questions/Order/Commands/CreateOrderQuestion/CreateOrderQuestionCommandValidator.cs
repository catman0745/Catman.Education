namespace Catman.Education.Application.Features.Questions.Order.Commands.CreateOrderQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;
    using FluentValidation;

    public class CreateOrderQuestionCommandValidator : AbstractValidator<CreateOrderQuestionCommand>
    {
        public class ItemValidator : AbstractValidator<CreateOrderQuestionCommand.Item>
        {
            public ItemValidator(ILocalizer localizer)
            {
                RuleFor(command => command.Text).ValidQuestionItemText(localizer);
            }
        }
        
        public CreateOrderQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionCommandValidator<OrderQuestion>(localizer));
            RuleForEach(question => question.OrderItems).SetValidator(new ItemValidator(localizer));
        }
    }
}
