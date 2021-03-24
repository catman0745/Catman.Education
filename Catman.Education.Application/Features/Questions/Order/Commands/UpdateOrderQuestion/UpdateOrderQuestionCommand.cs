namespace Catman.Education.Application.Features.Questions.Order.Commands.UpdateOrderQuestion
{
    using System;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;

    public class UpdateOrderQuestionCommand : UpdateQuestionCommand
    {
        public UpdateOrderQuestionCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
