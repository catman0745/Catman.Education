namespace Catman.Education.Application.Features.Questions.Value.Commands.UpdateValueQuestion
{
    using System;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;

    public class UpdateValueQuestionCommand : UpdateQuestionCommand
    {
        public string CorrectAnswer { get; set; }
        
        public UpdateValueQuestionCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
