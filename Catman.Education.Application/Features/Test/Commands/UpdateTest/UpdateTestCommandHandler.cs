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

        public UpdateTestCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }

        protected override async Task<RequestResult> HandleAsync(UpdateTestCommand updateCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound($"Test with id \"{updateCommand.Id}\" not found");
            }
            var test = await _store.Tests.WithIdAsync(updateCommand.Id);
            
            if (!await _store.Disciplines.ExistsWithIdAsync(updateCommand.DisciplineId))
            {
                return NotFound($"Discipline with id \"{updateCommand.DisciplineId}\" not found");
            }
            var discipline = await _store.Disciplines.WithIdAsync(updateCommand.DisciplineId);
            
            if (await _store.Tests.OtherThan(test).OfDiscipline(discipline).ExistsWithTitleAsync(updateCommand.Title))
            {
                return ValidationError("title", "Must be unique");
            }

            _mapper.Map(updateCommand, test);
            await _store.SaveChangesAsync();

            return Success($"Test with id \"{test.Id}\" updated successfully");
        }
    }
}
