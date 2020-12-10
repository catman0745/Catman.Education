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

        public CreateTestCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }

        protected override async Task<ResourceRequestResult<Test>> HandleAsync(CreateTestCommand createCommand)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(createCommand.DisciplineId))
            {
                return NotFound($"Discipline with id \"{createCommand.DisciplineId}\" not found");
            }
            var discipline = await _store.Disciplines.WithIdAsync(createCommand.DisciplineId);

            if (await _store.Tests.OfDiscipline(discipline).ExistsWithTitleAsync(createCommand.Title))
            {
                return ValidationError("title", "Must be unique");
            }

            var test = _mapper.Map<Test>(createCommand);
            _store.Tests.Add(test);
            await _store.SaveChangesAsync();

            return Success($"Test with id \"{test.Id}\" created successfully", test);
        }
    }
}
