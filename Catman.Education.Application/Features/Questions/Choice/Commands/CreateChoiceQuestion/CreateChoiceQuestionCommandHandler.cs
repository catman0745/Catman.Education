namespace Catman.Education.Application.Features.Questions.Choice.Commands.CreateChoiceQuestion
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class CreateChoiceQuestionCommandHandler
        : ResourceRequestHandlerBase<CreateChoiceQuestionCommand, ChoiceQuestion>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateChoiceQuestionCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<ChoiceQuestion>> HandleAsync(
            CreateChoiceQuestionCommand createCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(createCommand.TestId))
            {
                return NotFound(_localizer.TestNotFound(createCommand.TestId));
            }
            var test = await _store.Tests.WithIdAsync(createCommand.TestId);
            
            var teacher = await _store.Teachers
                .IncludeDisciplines()
                .WithIdAsync(createCommand.RequestorId);
            if (teacher.TaughtDisciplines.All(discipline => discipline.Id != test.DisciplineId))
            {
                return AccessViolation(_localizer.TeacherHasNoAccessToDiscipline(test.DisciplineId));
            }

            var question = _mapper.Map<ChoiceQuestion>(createCommand);
            _store.ChoiceQuestions.Add(question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionCreated(question.Id), question);
        }
    }
}
