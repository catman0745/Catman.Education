namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Teacher.Commands.RegisterTeacher;
    using Catman.Education.Application.Features.Teacher.Commands.UpdateTeacher;
    using Catman.Education.Application.Features.Teacher.Queries.GetTaughtDisciplinesIds;
    using Catman.Education.Application.Features.Teacher.Queries.GetTeachers;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Teacher;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class TeachersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TeachersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary> Get paginated teachers </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResourceSuccessResponse<PaginatedDto<TeacherDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTeachers([FromQuery] GetTeachersDto getDto)
        {
            var getQuery = _mapper.Map<GetTeachersQuery>(getDto);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(paginated =>
            {
                var dto = _mapper.Map<PaginatedDto<TeacherDto>>(paginated);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Register a new teacher according to the specified registration parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<TeacherDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Register([FromBody] RegisterTeacherDto registerDto)
        {
            var registerCommand = new RegisterTeacherCommand(UserId);
            _mapper.Map(registerDto, registerCommand);

            var result = await _mediator.Send(registerCommand);
            return result.ToActionResult(teacher =>
            {
                var dto = _mapper.Map<TeacherDto>(teacher);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Update the teacher with matching id according to the specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTeacherDto updateDto)
        {
            var updateCommand = new UpdateTeacherCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }

        /// <summary> Retrieve the IDs of all disciplines taught by the teacher with the specified teacherId </summary>
        [HttpGet("{teacherId}/disciplines")]
        [ProducesResponseType(typeof(ResourceSuccessResponse<ICollection<Guid>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTaughtDisciplinesIds([FromRoute] Guid teacherId)
        {
            var getTaughtDisciplinesIdsQuery = new GetTaughtDisciplinesIdsQuery(teacherId);

            var result = await _mediator.Send(getTaughtDisciplinesIdsQuery);
            return result.ToActionResult(taughtDisciplinesIds => Ok(Success(result.Message, taughtDisciplinesIds)));
        }
    }
}
