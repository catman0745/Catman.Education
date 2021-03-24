namespace Catman.Education.Application.Features.QuestionItems.Order.Commands.CreateOrderQuestionItem
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.CreateQuestionItem;

    public class CreateOrderQuestionItemCommand : CreateQuestionItemCommand<OrderQuestionItem>
    {
        public byte OrderIndex { get; set; }
        
        public CreateOrderQuestionItemCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
