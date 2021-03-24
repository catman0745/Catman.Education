namespace Catman.Education.Application.Entities.Testing.Questioning
{
    using System.Collections.Generic;

    public class OrderQuestion : Question
    {
        public ICollection<OrderQuestionItem> OrderItems { get; set; }
    }
}
