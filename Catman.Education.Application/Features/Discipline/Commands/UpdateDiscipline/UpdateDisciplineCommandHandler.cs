namespace Catman.Education.Application.Features.Discipline.Commands.UpdateDiscipline
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class UpdateDisciplineCommandHandler : RequestHandlerBase<UpdateDisciplineCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public UpdateDisciplineCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<RequestResult> HandleAsync(
            UpdateDisciplineCommand updateCommand)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound($"Discipline with id \"{updateCommand.Id}\" not found");
            }
            var discipline = await _store.Disciplines.WithIdAsync(updateCommand.Id);

            if (await _store.Disciplines.OtherThan(discipline).ExistsWithTitleAsync(updateCommand.Title))
            {
                return ValidationError("title", "Must be unique");
            }

            _mapper.Map(updateCommand, discipline);
            await _store.SaveChangesAsync();

            return Success($"Discipline with id \"{discipline.Id}\" updated successfully");
        }
    }
}
