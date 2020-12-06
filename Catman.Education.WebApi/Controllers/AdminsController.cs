namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Admin.Commands.RegisterAdmin;
    using Catman.Education.Application.Features.Admin.Commands.UpdateAdmin;
    using Catman.Education.Application.Features.User.Queries.GetUser;
    using Catman.Education.WebApi.DataTransferObjects.Admin;
    using Catman.Education.WebApi.Extensions;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class AdminsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AdminsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Get the admin with matching id </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdminDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var getQuery = new GetUserQuery(id);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(admin =>
            {
                var dto = _mapper.Map<AdminDto>(admin);
                return Ok(dto);
            });
        }

        /// <summary> Registers a new admin with the specified registration parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(AdminDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Register([FromBody] RegisterAdminDto registerDto)
        {
            var registerCommand = new RegisterAdminCommand(UserId);
            _mapper.Map(registerDto, registerCommand);

            var result = await _mediator.Send(registerCommand);
            return result.ToActionResult(admin =>
            {
                var dto = _mapper.Map<AdminDto>(admin);
                return CreatedAtAction(nameof(Get), new {admin.Id}, dto);
            });
        }

        /// <summary> Updates the admin with matching id with specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAdminDto updateDto)
        {
            var updateCommand = new UpdateAdminCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(Ok);
        }
    }
}
