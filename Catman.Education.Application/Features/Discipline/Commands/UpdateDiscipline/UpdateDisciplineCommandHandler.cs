namespace Catman.Education.Application.Features.Discipline.Commands.UpdateDiscipline
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Models.Result;

    internal class UpdateDisciplineCommandHandler : RequestHandlerBase<UpdateDisciplineCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateDisciplineCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(
            UpdateDisciplineCommand updateCommand)
        {
            if (!await _store.Disciplines.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.DisciplineNotFound(updateCommand.Id));
            }
            var discipline = await _store.Disciplines.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, discipline);
            await _store.SaveChangesAsync();

            return Success(_localizer.DisciplineUpdated(discipline.Id));
        }
    }
}
