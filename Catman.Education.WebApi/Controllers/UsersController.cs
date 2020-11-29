namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.User.Commands;
    using Catman.Education.Application.Features.User.Queries;
    using Catman.Education.WebApi.DataTransferObjects.User;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserAuthorizationDto authorizationDto)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(authorizationDto);
            try
            {
                var user = await _mediator.Send(registerCommand);
                var userDto = _mapper.Map<UserDto>(user);
                return StatusCode(StatusCodes.Status201Created, userDto);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("token")]
        public async Task<IActionResult> GenerateToken(UserAuthorizationDto authorizationDto)
        {
            var tokenQuery = _mapper.Map<GenerateTokenQuery>(authorizationDto);
            try
            {
                var token = await _mediator.Send(tokenQuery);
                return Ok(token);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
