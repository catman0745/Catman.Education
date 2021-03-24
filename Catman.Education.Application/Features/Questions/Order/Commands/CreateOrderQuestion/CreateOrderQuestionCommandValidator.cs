namespace Catman.Education.Application.Features.Questions.Order.Commands.CreateOrderQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;
    using FluentValidation;

    public class CreateOrderQuestionCommandValidator : AbstractValidator<CreateOrderQuestionCommand>
    {
        public CreateOrderQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new CreateQuestionCommandValidator<OrderQuestion>(localizer));
        }
    }
}
