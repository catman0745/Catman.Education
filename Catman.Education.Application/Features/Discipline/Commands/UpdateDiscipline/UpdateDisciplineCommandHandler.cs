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
                
                var message = _localizer["Discipline with id not found"].Replace("{id}", updateCommand.Id.ToString());
                return NotFound(message);
            }
            var discipline = await _store.Disciplines.WithIdAsync(updateCommand.Id);

            if (await _store.Disciplines.OtherThan(discipline).ExistsWithTitleAsync(updateCommand.Title))
            {
                return ValidationError("title", _localizer["Must be unique"]);
            }

            _mapper.Map(updateCommand, discipline);
            await _store.SaveChangesAsync();

            return Success(_localizer["Discipline with id updated"].Replace("{id}", discipline.Id.ToString()));
        }
    }
}
