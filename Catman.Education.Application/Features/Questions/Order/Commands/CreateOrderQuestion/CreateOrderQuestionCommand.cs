namespace Catman.Education.Application.Features.Questions.Order.Commands.CreateOrderQuestion
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;

    public class CreateOrderQuestionCommand : CreateQuestionCommand<OrderQuestion>
    {
        public class Item
        {
            public string Text { get; set; }
            
            public byte OrderIndex { get; set; }
        }
        
        public ICollection<Item> Items { get; set; }
        
        public CreateOrderQuestionCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
