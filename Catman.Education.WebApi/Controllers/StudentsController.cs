namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Student.Commands.RegisterStudent;
    using Catman.Education.Application.Features.Student.Commands.UpdateStudent;
    using Catman.Education.Application.Features.Student.Queries.GetStudent;
    using Catman.Education.WebApi.DataTransferObjects.Student;
    using Catman.Education.WebApi.Extensions;
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
        
        /// <summary> Get the student with matching id </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var getQuery = new GetStudentQuery(id);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(student =>
            {
                var dto = _mapper.Map<StudentDto>(student);
                return Ok(dto);
            });
        }
        
        /// <summary> Registers a new student with the specified registration parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(StudentDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Register([FromBody] RegisterStudentDto registerDto)
        {
            var registerCommand = new RegisterStudentCommand(UserId);
            _mapper.Map(registerDto, registerCommand);

            var result = await _mediator.Send(registerCommand);
            return result.ToActionResult(student =>
            {
                var dto = _mapper.Map<StudentDto>(student);
                return CreatedAtAction(nameof(Get), new {student.Id}, dto);
            });
        }

        /// <summary> Updates the student with matching id with specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStudentDto updateDto)
        {
            var updateCommand = new UpdateStudentCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(Ok);
        }
    }
}
