namespace Catman.Education.WebApi.Controllers.Questions
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Questions.Value.Commands.CreateValueQuestion;
    using Catman.Education.Application.Features.Questions.Value.Commands.UpdateValueQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.ValueQuestion;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/questions/value")]
    public class ValueQuestionsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ValueQuestionsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary> Create a new value question according to the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<ValueQuestionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateValueQuestionDto createDto)
        {
            var createCommand = new CreateValueQuestionCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(question =>
            {
                var dto = _mapper.Map<ValueQuestionDto>(question);
                var response = Success(result.Message, dto);
                return CreatedAtRoute(nameof(QuestionsController.GetQuestion), new {question.Id}, response);
            });
        }
        
        /// <summary>
        ///     Update the value question with matching id according to the specified updation parameters
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
            [FromBody] UpdateValueQuestionDto updateDto)
        {
            var updateCommand = new UpdateValueQuestionCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
