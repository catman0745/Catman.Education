namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.User.Commands.RemoveUser;
    using Catman.Education.Application.Features.User.Queries.GenerateToken;
    using Catman.Education.Application.Features.User.Queries.GetUser;
    using Catman.Education.Application.Features.User.Queries.GetUsers;
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

        /// <summary> Get all users </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getQuery = new GetUsersQuery();

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(users =>
            {
                var dtos = _mapper.Map<ICollection<UserDto>>(users);
                return Ok(dtos);
            });
        }

        /// <summary> Get the user with matching id </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var getQuery = new GetUserQuery(id);
            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(user => Ok(_mapper.Map<UserDto>(user)));
        }

        /// <summary> Generate token for specified user </summary>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GenerateToken([FromBody] GenerateTokenDto tokenDto)
        {
            var tokenQuery = _mapper.Map<GenerateTokenQuery>(tokenDto);
            var result = await _mediator.Send(tokenQuery);
            return result.ToActionResult(Ok);
        }

        /// <summary> Remove the user with matching id </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var removeCommand = new RemoveUserCommand(id, UserId);
            var result = await _mediator.Send(removeCommand);
            return result.ToActionResult(Ok);
        }
    }
}
