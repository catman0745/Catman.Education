namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Admin.Commands.RegisterAdmin;
    using Catman.Education.Application.Features.Admin.Commands.UpdateAdmin;
    using Catman.Education.Application.Features.Admin.Queries.GetAdmins;
    using Catman.Education.WebApi.DataTransferObjects.Admin;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
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

        /// <summary> Get paginated admins </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResourceSuccessResponse<PaginatedDto<AdminDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAdmins([FromQuery] GetAdminsDto getDto)
        {
            var getQuery = _mapper.Map<GetAdminsQuery>(getDto);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(paginated =>
            {
                var dto = _mapper.Map<PaginatedDto<AdminDto>>(paginated);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Register a new admin according to the specified registration parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<AdminDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Register([FromBody] RegisterAdminDto registerDto)
        {
            var registerCommand = new RegisterAdminCommand(UserId);
            _mapper.Map(registerDto, registerCommand);

            var result = await _mediator.Send(registerCommand);
            return result.ToActionResult(admin =>
            {
                var dto = _mapper.Map<AdminDto>(admin);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Update the admin with matching id according to the specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAdminDto updateDto)
        {
            var updateCommand = new UpdateAdminCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
