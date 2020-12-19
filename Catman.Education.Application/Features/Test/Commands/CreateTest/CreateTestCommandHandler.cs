namespace Catman.Education.Application.Features.Test.Commands.CreateTest
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results.Common;

    internal class CreateTestCommandHandler : ResourceRequestHandlerBase<CreateTestCommand, Test>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateTestCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }

        protected override async Task<ResourceRequestResult<Test>> HandleAsync(CreateTestCommand createCommand)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(createCommand.DisciplineId))
            {
                return NotFound(_localizer.DisciplineNotFound(createCommand.DisciplineId));
            }
            var discipline = await _store.Disciplines.WithIdAsync(createCommand.DisciplineId);

            if (await _store.Tests.OfDiscipline(discipline).ExistsWithTitleAsync(createCommand.Title))
            {
                return ValidationError("title", _localizer.MustBeUnique());
            }

            var test = _mapper.Map<Test>(createCommand);
            _store.Tests.Add(test);
            await _store.SaveChangesAsync();

            return Success(_localizer.TestCreated(test.Id), test);
        }
    }
}
