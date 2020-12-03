namespace Catman.Education.WebApi.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.User.Commands.RegisterUser;
    using Catman.Education.Application.Features.User.Commands.RemoveUser;
    using Catman.Education.Application.Features.User.Commands.UpdateUser;
    using Catman.Education.Application.Features.User.Queries.GenerateToken;
    using Catman.Education.Application.Features.User.Queries.GetUser;
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

        /// <summary> Get the user with matching username </summary>
        [HttpGet("{username}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            var getQuery = new GetUserQuery(username);
            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(user => Ok(_mapper.Map<UserDto>(user)));
        }

        /// <summary> Register a new user with the specified registration parameters </summary>
        [HttpPost("register")]
        [Authorize]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        /// <summary> Generate token for specified user </summary>
        [HttpPost("token")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GenerateToken([FromBody] GenerateTokenDto tokenDto)
        {
            var tokenQuery = _mapper.Map<GenerateTokenQuery>(tokenDto);
            var result = await _mediator.Send(tokenQuery);
            return result.ToActionResult(Ok);
        }

        /// <summary> Update the user with matching username with the specified updation parameters </summary>
        [HttpPut("{username}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] string username, [FromBody] UpdateUserDto updateDto)
        {
            var updateCommand = new UpdateUserCommand(username, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(Ok);
        }

        /// <summary> Remove the user with matching username </summary>
        [HttpDelete("{username}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] string username)
        {
            var removeCommand = new RemoveUserCommand(username, UserId);
            var result = await _mediator.Send(removeCommand);
            return result.ToActionResult(Ok);
        }
    }
}
