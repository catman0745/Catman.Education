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
        private readonly ILocalizer _localizer;

        public CreateGroupCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Group>> HandleAsync(CreateGroupCommand createCommand)
        {
            if (await _store.Groups.ExistsWithTitleAsync(createCommand.Title))
            {
                return ValidationError("title", _localizer.MustBeUnique());
            }

            var group = _mapper.Map<Group>(createCommand);
            _store.Groups.Add(group);
            await _store.SaveChangesAsync();

            return Success(_localizer.GroupCreated(group.Id), group);
        }
    }
}
