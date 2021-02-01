namespace Catman.Education.Application.Entities.Testing.Questioning
{
    using System.Collections.Generic;

    public class MultipleChoiceQuestion : Question
    {
        public ICollection<MultipleChoiceQuestionAnswerOption> AnswerOptions { get; set; }
    }
}
