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

        public UpdateAdminCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateAdminCommand updateCommand)
        {
            if (!await _store.Admins.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound($"Admin with id \"{updateCommand.Id}\" not found");
            }
            var admin = await _store.Admins.WithIdAsync(updateCommand.Id);

            if (await _store.Users.OtherThan(admin).ExistsWithUsernameAsync(updateCommand.Username))
            {
                return ValidationError("username", "Must be unique");
            }

            _mapper.Map(updateCommand, admin);
            await _store.SaveChangesAsync();

            return Success($"Admin with id \"{admin.Id}\" updated successfully");
        }
    }
}
