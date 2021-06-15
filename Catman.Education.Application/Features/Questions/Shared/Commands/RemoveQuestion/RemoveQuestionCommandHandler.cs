namespace Catman.Education.Application.Features.Questions.Shared.Commands.RemoveQuestion
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;
    using Microsoft.EntityFrameworkCore;

    internal class RemoveQuestionCommandHandler : RequestHandlerBase<RemoveQuestionCommand>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public RemoveQuestionCommandHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(RemoveQuestionCommand removeCommand)
        {
            if (!await _store.Questions.ExistsWithIdAsync(removeCommand.Id))
            {
                return NotFound(_localizer.QuestionNotFound(removeCommand.Id));
            }
            var question = await _store.Questions
                .Include(q => q.Items)
                .Include(q => q.Test)
                .WithIdAsync(removeCommand.Id);
            
            var teacher = await _store.Teachers
                .IncludeDisciplines()
                .WithIdAsync(removeCommand.RequestorId);
            if (teacher.TaughtDisciplines.All(discipline => discipline.Id != question.Test.DisciplineId))
            {
                return AccessViolation(_localizer.TeacherHasNoAccessToDiscipline(question.Test.DisciplineId));
            }

            _store.Questions.Remove(question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionRemoved(question.Id));
        }
    }
}
