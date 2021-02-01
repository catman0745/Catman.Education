namespace Catman.Education.Application.Features.Test.Commands.CreateTest
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Models.Result;

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
                return NotFound(_localizer.DisciplineNotFound(createCommand.DisciplineId));
            }

            var test = _mapper.Map<Test>(createCommand);
            _store.Tests.Add(test);
            await _store.SaveChangesAsync();

            return Success(_localizer.TestCreated(test.Id), test);
        }
    }
}
