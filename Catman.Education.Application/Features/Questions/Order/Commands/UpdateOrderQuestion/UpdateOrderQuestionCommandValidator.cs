namespace Catman.Education.Application.Features.Questions.Order.Commands.UpdateOrderQuestion
{
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;
    using FluentValidation;

    public class UpdateOrderQuestionCommandValidator : AbstractValidator<UpdateOrderQuestionCommand>
    {
        public UpdateOrderQuestionCommandValidator(ILocalizer localizer)
        {
            Include(new UpdateQuestionCommandValidator(localizer));
        }
    }
}
