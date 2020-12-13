namespace Catman.Education.Application.Features.Admin.Commands.UpdateAdmin
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class UpdateAdminCommandHandler : RequestHandlerBase<UpdateAdminCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateAdminCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateAdminCommand updateCommand)
        {
            if (!await _store.Admins.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer["Admin with id not found"].Replace("{id}", updateCommand.Id.ToString()));
            }
            var admin = await _store.Admins.WithIdAsync(updateCommand.Id);

            if (await _store.Users.OtherThan(admin).ExistsWithUsernameAsync(updateCommand.Username))
            {
                return ValidationError("username", _localizer["Must be unique"]);
            }

            _mapper.Map(updateCommand, admin);
            await _store.SaveChangesAsync();

            return Success(_localizer["Admin with id updated"].Replace("{id}", admin.Id.ToString()));
        }
    }
}
