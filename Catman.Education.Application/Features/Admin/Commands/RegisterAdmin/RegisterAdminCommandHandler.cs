namespace Catman.Education.Application.Features.Admin.Commands.RegisterAdmin
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Results.Common;

    internal class RegisterAdminCommandHandler : ResourceRequestHandlerBase<RegisterAdminCommand, Admin>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public RegisterAdminCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Admin>> HandleAsync(RegisterAdminCommand registerCommand)
        {
            if (await _store.Users.ExistsWithUsernameAsync(registerCommand.Username))
            {
                return ValidationError("username", _localizer.MustBeUnique());
            }

            var admin = _mapper.Map<Admin>(registerCommand);
            _store.Admins.Add(admin);
            await _store.SaveChangesAsync();

            return Success(_localizer.AdminRegistered(admin.Id), admin);
        }
    }
}
