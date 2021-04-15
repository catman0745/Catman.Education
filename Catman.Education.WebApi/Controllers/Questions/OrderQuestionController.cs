namespace Catman.Education.WebApi.Controllers.Questions
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Questions.Order.Commands.CreateOrderQuestion;
    using Catman.Education.Application.Features.Questions.Order.Commands.UpdateOrderQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Order;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/questions/order")]
    public class OrderQuestionsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderQuestionsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Create a new order question according to the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<OrderQuestionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateOrderQuestionDto createDto)
        {
            var createCommand = new CreateOrderQuestionCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(question =>
            {
                var dto = _mapper.Map<OrderQuestionDto>(question);
                var response = Success(result.Message, dto);
                return CreatedAtRoute(nameof(QuestionsController.GetQuestion), new {question.Id}, response);
            });
        }
        
        /// <summary>
        ///     Update the order question with matching id according to the specified updation parameters
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateOrderQuestionDto updateDto)
        {
            var updateCommand = new UpdateOrderQuestionCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
