namespace Catman.Education.WebApi.Controllers.Questions
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Questions.YesNo.Commands.CreateYesNoQuestion;
    using Catman.Education.Application.Features.Questions.YesNo.Commands.UpdateYesNoQuestion;
    using Catman.Education.WebApi.DataTransferObjects.Questions.YesNoQuestion;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Microsoft.AspNetCore.Components.Route("api/questions/yesno")]
    public class YesNoQuestionsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public YesNoQuestionsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary> Create a new yes/no question according to the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<YesNoQuestionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateYesNoQuestionDto createDto)
        {
            var createCommand = new CreateYesNoQuestionCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(question =>
            {
                var dto = _mapper.Map<YesNoQuestionDto>(question);
                var response = Success(result.Message, dto);
                return CreatedAtRoute(nameof(QuestionsController.GetQuestion), new {question.Id}, response);
            });
        }
        
        /// <summary>
        ///     Update the yes/no question with matching id according to the specified updation parameters
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
            [FromBody] UpdateYesNoQuestionDto updateDto)
        {
            var updateCommand = new UpdateYesNoQuestionCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
