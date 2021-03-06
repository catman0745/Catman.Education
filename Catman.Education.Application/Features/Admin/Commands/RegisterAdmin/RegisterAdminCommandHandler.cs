namespace Catman.Education.Application.Features.Admin.Commands.RegisterAdmin
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Models.Result;

    internal class RegisterAdminCommandHandler : ResourceRequestHandlerBase<RegisterAdminCommand, Admin>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public RegisterAdminCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Admin>> HandleAsync(RegisterAdminCommand registerCommand)
        {
            var admin = _mapper.Map<Admin>(registerCommand);
            _store.Admins.Add(admin);
            await _store.SaveChangesAsync();

            return Success(_localizer.AdminRegistered(admin.Id), admin);
        }
    }
}
