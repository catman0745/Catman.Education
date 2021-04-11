namespace Catman.Education.WebApi.Controllers.Questions
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Questions.Shared.Commands.RemoveQuestion;
    using Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestion;
    using Catman.Education.Application.Features.Questions.Shared.Queries.GetQuestions;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/questions")]
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
        [HttpGet("{id}", Name = nameof(GetQuestion))]
        [ProducesResponseType(typeof(ResourceSuccessResponse<FullyPopulatedQuestionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetQuestion([FromRoute] Guid id)
        {
            var getQuery = new GetQuestionQuery(id);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(question =>
            {
                var dto = _mapper.Map<FullyPopulatedQuestionDto>(question);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Get filtered and paginated questions </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResourceSuccessResponse<PaginatedDto<QuestionDto>>), StatusCodes.Status200OK)]
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
