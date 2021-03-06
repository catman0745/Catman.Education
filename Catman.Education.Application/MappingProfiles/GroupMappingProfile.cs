namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Features.Group.Commands.CreateGroup;
    using Catman.Education.Application.Features.Group.Commands.UpdateGroup;

    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<CreateGroupCommand, Group>();
            CreateMap<UpdateGroupCommand, Group>()
                .ForMember(group => group.Id, options => options.Ignore());
        }
    }
}
