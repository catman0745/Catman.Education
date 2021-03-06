namespace Catman.Education.Application.Features.Group.Commands.UpdateGroup
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Models.Result;

    internal class UpdateGroupCommandHandler : RequestHandlerBase<UpdateGroupCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateGroupCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateGroupCommand updateCommand)
        {
            if (!await _store.Groups.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.GroupNotFound(updateCommand.Id));
            }
            var group = await _store.Groups.WithIdAsync(updateCommand.Id);
            
            _mapper.Map(updateCommand, group);
            await _store.SaveChangesAsync();

            return Success(_localizer.GroupUpdated(group.Id));
        }
    }
}
