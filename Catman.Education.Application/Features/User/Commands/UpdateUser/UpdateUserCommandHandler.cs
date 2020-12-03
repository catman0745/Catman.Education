namespace Catman.Education.Application.Features.User.Commands.UpdateUser
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class UpdateUserCommandHandler : RequestHandlerBase<UpdateUserCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }

        protected override async Task<RequestResult> HandleAsync(UpdateUserCommand updateCommand)
        {
            if (!await _store.Users.ExistsWithUsernameAsync(updateCommand.OldUsername))
            {
                return NotFound();
            }
            var user = await _store.Users.WithUsernameAsync(updateCommand.OldUsername);

            if (await _store.Users.OtherThan(user).ExistsWithUsernameAsync(updateCommand.Username))
            {
                return Duplicate("User with such username already exists");
            }

            _mapper.Map(updateCommand, user);
            await _store.SaveChangesAsync();

            return Success();
        }
    }
}
