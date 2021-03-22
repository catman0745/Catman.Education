namespace Catman.Education.Application.Features.Questions.YesNo.Commands.UpdateYesNoQuestion
{
    using System;
    using Catman.Education.Application.Features.Questions.Shared.Commands.UpdateQuestion;

    public class UpdateYesNoQuestionCommand : UpdateQuestionCommand
    {
        public bool CorrectAnswer { get; set; }

        public UpdateYesNoQuestionCommand(Guid id, Guid requestorId)
            : base(id, requestorId)
        {
        }
    }
}
