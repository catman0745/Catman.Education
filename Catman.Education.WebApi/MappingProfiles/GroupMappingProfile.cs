namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Features.Group.Commands.CreateGroup;
    using Catman.Education.Application.Features.Group.Commands.UpdateGroup;
    using Catman.Education.WebApi.DataTransferObjects.Group;

    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<Group, GroupDto>();
            CreateMap<CreateGroupDto, CreateGroupCommand>();
            CreateMap<UpdateGroupDto, UpdateGroupCommand>();
        }
    }
}
