namespace Catman.Education.Application.Entities.Testing.Questioning
{
    using System;

    public class OrderQuestionItem : QuestionItem
    {
        public byte OrderIndex { get; set; }
        
        public Guid OrderQuestionId { get; set; }
        
        public OrderQuestion OrderQuestion { get; set; }
    }
}
