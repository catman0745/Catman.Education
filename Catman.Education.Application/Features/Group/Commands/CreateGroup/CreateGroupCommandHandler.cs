namespace Catman.Education.Application.Features.Group.Commands.CreateGroup
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class CreateGroupCommandHandler : ResourceRequestHandlerBase<CreateGroupCommand, Group>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public CreateGroupCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<ResourceRequestResult<Group>> HandleAsync(CreateGroupCommand createCommand)
        {
            if (await _store.Groups.ExistsWithTitleAsync(createCommand.Title))
            {
                return ValidationError("title", "Must be unique");
            }

            var group = _mapper.Map<Group>(createCommand);
            _store.Groups.Add(group);
            await _store.SaveChangesAsync();

            return Success($"Group with id \"{group.Id}\" created successfully", group);
        }
    }
}
