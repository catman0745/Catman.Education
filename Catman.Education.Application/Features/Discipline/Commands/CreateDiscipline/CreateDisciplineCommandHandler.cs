namespace Catman.Education.Application.Features.Discipline.Commands.CreateDiscipline
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class CreateDisciplineCommandHandler : ResourceRequestHandlerBase<CreateDisciplineCommand, Discipline>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public CreateDisciplineCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<ResourceRequestResult<Discipline>> HandleAsync(
            CreateDisciplineCommand createCommand)
        {
            if (await _store.Disciplines.ExistsWithTitleAsync(createCommand.Title))
            {
                return ValidationError("title", "Must be unique");
            }

            var discipline = _mapper.Map<Discipline>(createCommand);
            _store.Disciplines.Add(discipline);
            await _store.SaveChangesAsync();

            return Success($"Discipline with id \"{discipline.Id}\" created successfully", discipline);
        }
    }
}
