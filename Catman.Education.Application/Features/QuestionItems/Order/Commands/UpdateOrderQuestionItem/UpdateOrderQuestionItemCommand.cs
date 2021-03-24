namespace Catman.Education.Application.Features.QuestionItems.Order.Commands.UpdateOrderQuestionItem
{
    using System;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.UpdateQuestionItem;

    public class UpdateOrderQuestionItemCommand : UpdateQuestionItemCommand
    {
        public byte OrderIndex { get; set; }
        
        public UpdateOrderQuestionItemCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
