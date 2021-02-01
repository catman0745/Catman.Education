namespace Catman.Education.WebApi.Controllers.QuestionItems
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.QuestionItems.Shared.Commands.RemoveQuestionItem;
    using Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItem;
    using Catman.Education.Application.Features.QuestionItems.Shared.Queries.GetQuestionItems;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.Question;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/question_items")]
    public class QuestionItemsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public QuestionItemsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary> Get the question item with matching id </summary>
        [HttpGet("{id}", Name = nameof(GetQuestionItem))]
        [ProducesResponseType(typeof(ResourceSuccessResponse<QuestionItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetQuestionItem([FromRoute] Guid id)
        {
            var getQuery = new GetQuestionItemQuery(id);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(questionItem =>
            {
                var dto = _mapper.Map<QuestionItemDto>(questionItem);
                return Ok(Success(result.Message, dto));
            });
        }
        
        /// <summary> Get filtered and paginated question items </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResourceSuccessResponse<PaginatedDto<QuestionItemDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetQuestionItems([FromQuery] GetQuestionItemsDto getDto)
        {
            var getQuery = _mapper.Map<GetQuestionItemsQuery>(getDto);
        
            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(questionItems =>
            {
                var dtos = _mapper.Map<PaginatedDto<QuestionItemDto>>(questionItems);
                return Ok(Success(result.Message, dtos));
            });
        }
        
        /// <summary> Remove the question item with matching id </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var removeCommand = new RemoveQuestionItemCommand(id, UserId);

            var result = await _mediator.Send(removeCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
