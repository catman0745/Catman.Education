namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Answer.Commands.CreateAnswer;
    using Catman.Education.Application.Features.Answer.Commands.RemoveAnswer;
    using Catman.Education.Application.Features.Answer.Commands.UpdateAnswer;
    using Catman.Education.Application.Features.Answer.Queries.GetAnswer;
    using Catman.Education.Application.Features.Answer.Queries.GetAnswers;
    using Catman.Education.Application.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Answer;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class AnswersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AnswersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Get the answer with matching id </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResourceSuccessResponse<AnswerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAnswer([FromRoute] Guid id)
        {
            var getQuery = new GetAnswerQuery(id);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(answer =>
            {
                var dto = _mapper.Map<AnswerDto>(answer);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Get all answers </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResourceSuccessResponse<Paginated<AnswerDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAnswers([FromQuery] GetAnswersDto getDto)
        {
            var getQuery = _mapper.Map<GetAnswersQuery>(getDto);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(answers =>
            {
                var dtos = _mapper.Map<PaginatedDto<AnswerDto>>(answers);
                return Ok(Success(result.Message, dtos));
            });
        }

        /// <summary> Create a new answer with the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<AnswerDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateAnswerDto createDto)
        {
            var createCommand = new CreateAnswerCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(answer =>
            {
                var dto = _mapper.Map<AnswerDto>(answer);
                return CreatedAtAction(nameof(GetAnswer), new {answer.Id}, Success(result.Message, dto));
            });
        }

        /// <summary> Update the answer with matching id with the specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAnswerDto updateDto)
        {
            var updateCommand = new UpdateAnswerCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }

        /// <summary> Remove the answer with matching id </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var removeCommand = new RemoveAnswerCommand(id, UserId);

            var result = await _mediator.Send(removeCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
