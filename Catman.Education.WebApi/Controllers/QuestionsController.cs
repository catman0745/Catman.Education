namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Question.Commands.CreateQuestion;
    using Catman.Education.Application.Features.Question.Commands.RemoveQuestion;
    using Catman.Education.Application.Features.Question.Commands.UpdateQuestion;
    using Catman.Education.Application.Features.Question.Queries.GetQuestion;
    using Catman.Education.Application.Features.Question.Queries.GetQuestions;
    using Catman.Education.Application.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Question;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class QuestionsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public QuestionsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Get the question with matching id </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResourceSuccessResponse<QuestionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetQuestion([FromRoute] Guid id)
        {
            var getQuery = new GetQuestionQuery(id);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(question =>
            {
                var dto = _mapper.Map<QuestionDto>(question);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Get filtered and paginated questions </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResourceSuccessResponse<Paginated<QuestionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetQuestions([FromQuery] GetQuestionsDto getDto)
        {
            var getQuery = _mapper.Map<GetQuestionsQuery>(getDto);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(questions =>
            {
                var dtos = _mapper.Map<PaginatedDto<QuestionDto>>(questions);
                return Ok(Success(result.Message, dtos));
            });
        }

        /// <summary> Create a new question according to the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<QuestionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateQuestionDto createDto)
        {
            var createCommand = new CreateQuestionCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(question =>
            {
                var dto = _mapper.Map<QuestionDto>(question);
                return CreatedAtAction(nameof(GetQuestion), new {question.Id}, Success(result.Message, dto));
            });
        }

        /// <summary> Update the question with matching id according to the specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateQuestionDto updateDto)
        {
            var updateCommand = new UpdateQuestionCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }

        /// <summary> Remove the question with matching id </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var removeCommand = new RemoveQuestionCommand(id, UserId);

            var result = await _mediator.Send(removeCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
