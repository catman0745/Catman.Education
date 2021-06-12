namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Student.Commands.RegisterStudent;
    using Catman.Education.Application.Features.Student.Commands.UpdateStudent;
    using Catman.Education.Application.Features.Student.Queries.GetStudents;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Student;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class StudentsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StudentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Get filtered and paginated students </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResourceSuccessResponse<PaginatedDto<StudentDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStudents([FromQuery] GetStudentsDto getDto)
        {
            var getQuery = _mapper.Map<GetStudentsQuery>(getDto);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(paginated =>
            {
                var dto = _mapper.Map<PaginatedDto<StudentDto>>(paginated);
                return Ok(Success(result.Message, dto));
            });
        }
        
        /// <summary> Register a new student according to the specified registration parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<StudentDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Register([FromBody] RegisterStudentDto registerDto)
        {
            var registerCommand = new RegisterStudentCommand(UserId);
            _mapper.Map(registerDto, registerCommand);

            var result = await _mediator.Send(registerCommand);
            return result.ToActionResult(student =>
            {
                var dto = _mapper.Map<StudentDto>(student);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Update the student with matching id according to the specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStudentDto updateDto)
        {
            var updateCommand = new UpdateStudentCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
