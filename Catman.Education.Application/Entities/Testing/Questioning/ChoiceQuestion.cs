namespace Catman.Education.Application.Entities.Testing.Questioning
{
    using System.Collections.Generic;

    public class ChoiceQuestion : Question
    {
        public ICollection<ChoiceQuestionAnswerOption> AnswerOptions { get; set; }
    }
}
