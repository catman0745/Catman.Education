namespace Catman.Education.Application.Features.Test.Commands.CreateTest
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class CreateTestCommandHandler : ResourceRequestHandlerBase<CreateTestCommand, Test>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateTestCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<Test>> HandleAsync(CreateTestCommand createCommand)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(createCommand.DisciplineId))
            {
                var notFoundMessage = _localizer["Discipline with id not found"]
                    .Replace("{id}", createCommand.DisciplineId.ToString());
                
                return NotFound(notFoundMessage);
            }
            var discipline = await _store.Disciplines.WithIdAsync(createCommand.DisciplineId);

            if (await _store.Tests.OfDiscipline(discipline).ExistsWithTitleAsync(createCommand.Title))
            {
                return ValidationError("title", _localizer["Must be unique"]);
            }

            var test = _mapper.Map<Test>(createCommand);
            _store.Tests.Add(test);
            await _store.SaveChangesAsync();

            var message = _localizer["Test with id created"].Replace("{id}", test.Id.ToString());
            return Success(message, test);
        }
    }
}
