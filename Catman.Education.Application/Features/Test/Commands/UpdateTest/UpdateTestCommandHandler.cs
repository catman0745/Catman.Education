namespace Catman.Education.Application.Features.Test.Commands.UpdateTest
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class UpdateTestCommandHandler : RequestHandlerBase<UpdateTestCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateTestCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }

        protected override async Task<RequestResult> HandleAsync(UpdateTestCommand updateCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer["Test with id not found"].Replace("{id}", updateCommand.Id.ToString()));
            }
            var test = await _store.Tests.WithIdAsync(updateCommand.Id);
            
            if (!await _store.Disciplines.ExistsWithIdAsync(updateCommand.DisciplineId))
            {
                var notFoundMessage = _localizer["Discipline with id not found"]
                    .Replace("{id}", updateCommand.DisciplineId.ToString());
                
                return NotFound(notFoundMessage);
            }
            var discipline = await _store.Disciplines.WithIdAsync(updateCommand.DisciplineId);
            
            if (await _store.Tests.OtherThan(test).OfDiscipline(discipline).ExistsWithTitleAsync(updateCommand.Title))
            {
                return ValidationError("title", _localizer["Must be unique"]);
            }

            _mapper.Map(updateCommand, test);
            await _store.SaveChangesAsync();
            
            return Success(_localizer["Test with id updated"].Replace("{id}", test.Id.ToString()));
        }
    }
}
