namespace Catman.Education.Application.Features.Questions.Order.Commands.UpdateOrderQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Validation;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;
    using FluentValidation;

    public class UpdateOrderQuestionCommandValidator : AbstractValidator<UpdateOrderQuestionCommand>
    {
        public class ItemValidator : AbstractValidator<UpdateOrderQuestionCommand.Item>
        {
            public ItemValidator(ILocalizer localizer)
            {
                RuleFor(question => question.Text).ValidQuestionItemText(localizer);
            }
        }
        
        public UpdateOrderQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionCommandValidator(localizer));
            RuleForEach(question => question.OrderItems).SetValidator(new ItemValidator(localizer));
        }
    }
}
