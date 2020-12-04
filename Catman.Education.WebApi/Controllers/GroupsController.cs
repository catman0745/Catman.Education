namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Features.Group.Commands.CreateGroup;
    using Catman.Education.Application.Features.Group.Commands.RemoveGroup;
    using Catman.Education.Application.Features.Group.Commands.UpdateGroup;
    using Catman.Education.Application.Features.Group.Queries.GetGroup;
    using Catman.Education.Application.Features.Group.Queries.GetGroups;
    using Catman.Education.WebApi.DataTransferObjects.Group;
    using Catman.Education.WebApi.Extensions;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class GroupsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GroupsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary> Get the group with matching id </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GroupDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var getQuery = new GetGroupQuery(id);

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(group =>
            {
                var dto = _mapper.Map<GroupDto>(group);
                return Ok(dto);
            });
        }

        /// <summary> Get all groups </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<GroupDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getQuery = new GetGroupsQuery();

            var result = await _mediator.Send(getQuery);
            return result.ToActionResult(groups => 
            {
                var dtos = _mapper.Map<ICollection<GroupDto>>(groups);
                return Ok(dtos);
            });
        }

        /// <summary> Create a new group with the specified creation parameters </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(GroupDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateGroupDto createDto)
        {
            var createCommand = new CreateGroupCommand(UserId);
            _mapper.Map(createDto, createCommand);

            var result = await _mediator.Send(createCommand);
            return result.ToActionResult(group =>
            {
                var dto = _mapper.Map<GroupDto>(group);
                return CreatedAtAction(nameof(Get), new {group.Id}, dto);
            });
        }

        /// <summary> Update the group with matching id with the specified updation parameters </summary>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGroupDto updateDto)
        {
            var updateCommand = new UpdateGroupCommand(id, UserId);
            _mapper.Map(updateDto, updateCommand);

            var result = await _mediator.Send(updateCommand);
            return result.ToActionResult(Ok);
        }

        /// <summary> Remove the group with matching id </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var removeCommand = new RemoveGroupCommand(id, UserId);

            var result = await _mediator.Send(removeCommand);
            return result.ToActionResult(Ok);
        }
    }
}
