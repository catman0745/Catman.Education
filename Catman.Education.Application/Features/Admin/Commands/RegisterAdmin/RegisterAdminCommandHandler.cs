namespace Catman.Education.Application.Features.Admin.Commands.RegisterAdmin
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class RegisterAdminCommandHandler : ResourceRequestHandlerBase<RegisterAdminCommand, Admin>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public RegisterAdminCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<ResourceRequestResult<Admin>> HandleAsync(RegisterAdminCommand registerCommand)
        {
            if (await _store.Users.ExistsWithUsernameAsync(registerCommand.Username))
            {
                return Duplicate("User with such username already exists");
            }

            var admin = _mapper.Map<Admin>(registerCommand);
            _store.Admins.Add(admin);
            await _store.SaveChangesAsync();

            return Success(admin);
        }
    }
}
