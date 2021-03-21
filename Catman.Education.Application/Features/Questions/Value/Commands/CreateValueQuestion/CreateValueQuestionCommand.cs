namespace Catman.Education.Application.Features.Questions.Value.Commands.CreateValueQuestion
{
    using System;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Features.Questions.Shared.Commands.CreateQuestion;

    public class CreateValueQuestionCommand : CreateQuestionCommand<ValueQuestion>
    {
        public string CorrectAnswer { get; set; }
        
        public CreateValueQuestionCommand(Guid requestorId)
            : base(requestorId)
        {
        }
    }
}
