namespace Catman.Education.Application.Features.Discipline.Commands.CreateDiscipline
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Models.Result;

    internal class CreateDisciplineCommandHandler : ResourceRequestHandlerBase<CreateDisciplineCommand, Discipline>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateDisciplineCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Discipline>> HandleAsync(
            CreateDisciplineCommand createCommand)
        {
            var discipline = _mapper.Map<Discipline>(createCommand);
            _store.Disciplines.Add(discipline);
            await _store.SaveChangesAsync();

            return Success(_localizer.DisciplineCreated(discipline.Id), discipline);
        }
    }
}
