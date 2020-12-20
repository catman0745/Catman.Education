namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Testing.Commands.CheckTest;
    using Catman.Education.Application.Features.Testing.Queries.GetTesting;
    using Catman.Education.Application.Features.Testing.Queries.GetTestingResult;
    using Catman.Education.Application.Features.Testing.Queries.GetTestingResults;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Testing;
    using Catman.Education.WebApi.Extensions;
    using Catman.Education.WebApi.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class TestingController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TestingController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Get the test with matching id </summary>
        [HttpGet("{testId}")]
        [ProducesResponseType(typeof(ResourceSuccessResponse<TestingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTest([FromRoute] Guid testId)
        {
            var getQuery = new GetTestingQuery(testId);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(test =>
            {
                var dto = _mapper.Map<TestingDto>(test);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Get testing result for the student and test with matching ids </summary>
        [HttpGet("results/{testId}/{studentId}")]
        [ProducesResponseType(typeof(ResourceSuccessResponse<TestingResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTestingResult([FromRoute] Guid testId, [FromRoute] Guid studentId)
        {
            var getQuery = new GetTestingResultQuery(testId, studentId);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(testingResult =>
            {
                var dto = _mapper.Map<TestingResultDto>(testingResult);
                return Ok(Success(result.Message, dto));
            });
        }

        /// <summary> Get filtered and paginated testing results </summary>
        [HttpGet("results")]
        [ProducesResponseType(typeof(ResourceSuccessResponse<PaginatedDto<TestingResultDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTestingResult([FromQuery] GetTestingResultsDto getDto)
        {
            var getQuery = _mapper.Map<GetTestingResultsQuery>(getDto);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(testingResults =>
            {
                var dtos = _mapper.Map<PaginatedDto<TestingResultDto>>(testingResults);
                return Ok(Success(result.Message, dtos));
            });
        }

        /// <summary> Check the specified answers for a test with a matching id </summary>
        /// <param name="correctAnswersIds"> IDs of answers marked as correct </param>
        [HttpPost("{testId}")]
        [Authorize]
        [ProducesResponseType(typeof(ResourceSuccessResponse<TestCheckResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CheckAnswers(
            [FromRoute] Guid testId,
            [FromBody] ICollection<Guid> correctAnswersIds)
        {
            var checkQuery = new CheckTestCommand(testId, correctAnswersIds, UserId);

            var result = await _mediator.Send(checkQuery);
            return result.ToActionResult(testCheckResult =>
            {
                var dto = _mapper.Map<TestCheckResultDto>(testCheckResult);
                return Ok(Success(result.Message, dto));
            });
        }
    }
}
