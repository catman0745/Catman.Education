namespace Catman.Education.WebApi.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.User.Commands;
    using Catman.Education.Application.Features.User.Queries;
    using Catman.Education.WebApi.DataTransferObjects.User;
    using Catman.Education.WebApi.Extensions;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            var getQuery = new GetUserQuery(username);
            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(user => Ok(_mapper.Map<UserDto>(user)));
        }

        [HttpPost("register")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            var registerCommand = new RegisterUserCommand(UserId);
            _mapper.Map(registerDto, registerCommand);
            
            var result = await _mediator.Send(registerCommand);
            return result.ToActionResult(user =>
            {
                var dto = _mapper.Map<UserDto>(user);
                return StatusCode(StatusCodes.Status201Created, dto);
            });
        }

        [HttpPost("token")]
        public async Task<IActionResult> GenerateToken([FromBody] GenerateTokenDto tokenDto)
        {
            var tokenQuery = _mapper.Map<GenerateTokenQuery>(tokenDto);
            var result = await _mediator.Send(tokenQuery);
            return result.ToActionResult(Ok);
        }

        [HttpPut("{username}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Update([FromRoute] string username, [FromBody] UpdateUserDto updateDto)
        {
            var updateCommand = new UpdateUserCommand(username, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(Ok);
        }

        [HttpDelete("{username}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Remove([FromRoute] string username)
        {
            var removeCommand = new RemoveUserCommand(username, UserId);
            var result = await _mediator.Send(removeCommand);
            return result.ToActionResult(Ok);
        }
    }
}
