namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Discipline.Commands.CreateDiscipline;
    using Catman.Education.Application.Features.Discipline.Commands.RemoveDiscipline;
    using Catman.Education.Application.Features.Discipline.Commands.UpdateDiscipline;
    using Catman.Education.Application.Features.Discipline.Queries.GetDiscipline;
    using Catman.Education.Application.Features.Discipline.Queries.GetDisciplines;
    using Catman.Education.WebApi.DataTransferObjects.Discipline;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class DisciplinesController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DisciplinesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Get the discipline with matching id </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResourceSuccessResponse<DisciplineDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDiscipline([FromRoute] Guid id)
        {
            var getQuery = new GetDisciplineQuery(id);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(discipline =>
            {
                var dto = _mapper.Map<DisciplineDto>(discipline);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Get all disciplines </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResourceSuccessResponse<ICollection<DisciplineDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDisciplines()
        {
            var getQuery = new GetDisciplinesQuery();

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(disciplines =>
            {
                var dtos = _mapper.Map<ICollection<DisciplineDto>>(disciplines);
                return Ok(Success(result.Message, dtos));
            });
        }

        /// <summary> Create a new discipline with the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<DisciplineDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateDisciplineDto createDto)
        {
            var createCommand = new CreateDisciplineCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(discipline =>
            {
                var dto = _mapper.Map<DisciplineDto>(discipline);
                return CreatedAtAction(nameof(GetDiscipline), new {discipline.Id}, Success(result.Message, dto));
            });
        }

        /// <summary> Update the discipline with matching id with the specified updation parameters</summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateDisciplineDto updateDto)
        {
            var updateCommand = new UpdateDisciplineCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }

        /// <summary> Remove the discipline with matching id </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var removeCommand = new RemoveDisciplineCommand(id, UserId);

            var result = await _mediator.Send(removeCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
