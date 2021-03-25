namespace Catman.Education.WebApi.Controllers.QuestionItems
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.QuestionItems.Choice.Commands.CreateChoiceQuestionAnswerOption;
    using Catman.Education.Application.Features.QuestionItems.Choice.Commands.UpdateChoiceQuestionAnswerOption;
    using Catman.Education.WebApi.DataTransferObjects.QuestionItems.ChoiceQuestion;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/question_items/choice_question_answer_options")]
    public class ChoiceQuestionAnswerOptionsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ChoiceQuestionAnswerOptionsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary> Create a new answer option according to the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<ChoiceQuestionAnswerOptionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateChoiceQuestionAnswerOptionDto createDto)
        {
            var createCommand = new CreateChoiceQuestionAnswerOptionCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(answer =>
            {
                var dto = _mapper.Map<ChoiceQuestionAnswerOptionDto>(answer);
                var response = Success(result.Message, dto);
                return CreatedAtRoute(nameof(QuestionItemsController.GetQuestionItem), new {answer.Id}, response);
            });
        }

        /// <summary> Update the answer with matching id according to the specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateChoiceQuestionAnswerOptionDto updateDto)
        {
            var updateCommand = new UpdateChoiceQuestionAnswerOptionCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
