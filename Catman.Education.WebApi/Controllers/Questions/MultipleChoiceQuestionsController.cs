namespace Catman.Education.WebApi.Controllers.Questions
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.CreateMultipleChoiceQuestion;
    using Catman.Education.Application.Features.Questions.MultipleChoice.Commands.UpdateMultipleChoiceQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.MultipleChoiceQuestion;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/questions/multiple_choice")]
    public class MultipleChoiceQuestionsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MultipleChoiceQuestionsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Create a new multiple choice question according to the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<MultipleChoiceQuestionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateMultipleChoiceQuestionDto createDto)
        {
            var createCommand = new CreateMultipleChoiceQuestionCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(question =>
            {
                var dto = _mapper.Map<MultipleChoiceQuestionDto>(question);
                var response = Success(result.Message, dto);
                return CreatedAtRoute(nameof(QuestionsController.GetQuestion), new {question.Id}, response);
            });
        }
        
        /// <summary>
        ///     Update the multiple choice question with matching id according to the specified updation parameters
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
            [FromBody] UpdateMultipleChoiceQuestionDto updateDto)
        {
            var updateCommand = new UpdateMultipleChoiceQuestionCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
