namespace Catman.Education.Application.Features.Questions.Order.Commands.UpdateOrderQuestion
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;

    public class UpdateOrderQuestionCommand : UpdateQuestionCommand
    {
        public class Item
        {
            public string Text { get; set; }
            
            public int OrderIndex { get; set; }
        }
        
        public ICollection<Item> OrderItems { get; set; }
    
        public UpdateOrderQuestionCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
