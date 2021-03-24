namespace Catman.Education.Application.Features.Questions.Order.Commands.CreateOrderQuestion
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;

    public class CreateOrderQuestionCommand : CreateQuestionCommand<OrderQuestion>
    {
        public CreateOrderQuestionCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
