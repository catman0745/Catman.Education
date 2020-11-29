namespace Catman.Education.Application.Features.User.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class RegisterUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
    }

    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        public async Task<User> Handle(RegisterUserCommand command, CancellationToken _)
        {
            if (await _store.Users.AnyAsync(user => user.Username == command.Username))
            {
                throw new Exception("User with such username already exists");
            }

            var user = _mapper.Map<User>(command);
            _store.Users.Add(user);
            await _store.SaveChangesAsync();

            return user;
        }
    }
}
