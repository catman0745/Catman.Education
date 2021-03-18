namespace Catman.Education.Application.Features.Admin.Commands.UpdateAdmin
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Models.Result;

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
                return NotFound(_localizer.AdminNotFound(updateCommand.Id));
            }
            var admin = await _store.Admins.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, admin);
            await _store.SaveChangesAsync();

            return Success(_localizer.AdminUpdated(admin.Id));
        }
    }
}
