namespace Catman.Education.WebApi.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.User.Commands;
    using Catman.Education.Application.Features.User.Queries;
    using Catman.Education.WebApi.DataTransferObjects.User;
    using Catman.Education.WebApi.Extensions;
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
            var result = await _mediator.Send(registerCommand);
            return result.ToActionResult(user =>
            {
                var dto = _mapper.Map<UserDto>(user);
                return StatusCode(StatusCodes.Status201Created, dto);
            });
        }

        [HttpPost("token")]
        public async Task<IActionResult> GenerateToken(UserAuthorizationDto authorizationDto)
        {
            var tokenQuery = _mapper.Map<GenerateTokenQuery>(authorizationDto);
            var result = await _mediator.Send(tokenQuery);
            return result.ToActionResult(Ok);
        }
    }
}
