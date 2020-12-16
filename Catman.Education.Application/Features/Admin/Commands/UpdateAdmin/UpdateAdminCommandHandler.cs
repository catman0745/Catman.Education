namespace Catman.Education.Application.Features.Admin.Commands.UpdateAdmin
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results.Common;

    internal class UpdateAdminCommandHandler : RequestHandlerBase<UpdateAdminCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateAdminCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateAdminCommand updateCommand)
        {
            if (!await _store.Admins.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.AdminNotFound(updateCommand.Id));
            }
            var admin = await _store.Admins.WithIdAsync(updateCommand.Id);

            if (await _store.Users.OtherThan(admin).ExistsWithUsernameAsync(updateCommand.Username))
            {
                return ValidationError("username", _localizer.MustBeUnique());
            }

            _mapper.Map(updateCommand, admin);
            await _store.SaveChangesAsync();

            return Success(_localizer.AdminUpdated(admin.Id));
        }
    }
}
