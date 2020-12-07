namespace Catman.Education.Application.Features.Group.Commands.UpdateGroup
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class UpdateGroupCommandHandler : RequestHandlerBase<UpdateGroupCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public UpdateGroupCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateGroupCommand updateCommand)
        {
            if (!await _store.Groups.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound($"Group with id \"{updateCommand.Id}\" not found");
            }
            var group = await _store.Groups.WithIdAsync(updateCommand.Id);

            if (await _store.Groups.OtherThan(group).ExistsWithTitleAsync(updateCommand.Title))
            {
                return ValidationError("title", "Must be unique");
            }

            _mapper.Map(updateCommand, group);
            await _store.SaveChangesAsync();

            return Success($"Group with id \"{updateCommand.Id}\" updated successfully");
        }
    }
}
