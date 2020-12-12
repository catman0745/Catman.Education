namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Test.Commands.CreateTest;
    using Catman.Education.Application.Features.Test.Commands.RemoveTest;
    using Catman.Education.Application.Features.Test.Commands.UpdateTest;
    using Catman.Education.Application.Features.Test.Queries.GetTest;
    using Catman.Education.Application.Features.Test.Queries.GetTests;
    using Catman.Education.Application.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Test;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class TestsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TestsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Get the test with matching id </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResourceSuccessResponse<TestDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTest([FromRoute] Guid id)
        {
            var getQuery = new GetTestQuery(id);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(test =>
            {
                var dto = _mapper.Map<TestDto>(test);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Get filtered and paginated tests </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ResourceSuccessResponse<Paginated<TestDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTests([FromQuery] GetTestsDto getDto)
        {
            var getQuery = _mapper.Map<GetTestsQuery>(getDto);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(tests =>
            {
                var dtos = _mapper.Map<PaginatedDto<TestDto>>(tests);
                return Ok(Success(result.Message, dtos));
            });
        }

        /// <summary> Create a new test according to the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<TestDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateTestDto createDto)
        {
            var createCommand = new CreateTestCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(test =>
            {
                var dto = _mapper.Map<TestDto>(test);
                return CreatedAtAction(nameof(GetTest), new {test.Id}, Success(result.Message, dto));
            });
        }

        /// <summary> Update the test with matching id according to the specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTestDto updateDto)
        {
            var updateCommand = new UpdateTestCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }

        /// <summary> Remove the test with matching id </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var removeCommand = new RemoveTestCommand(id, UserId);

            var result = await _mediator.Send(removeCommand);
            return result.ToActionResult(() => Ok(Success(result.Message)));
        }
    }
}
