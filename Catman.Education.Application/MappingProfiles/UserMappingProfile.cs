namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.User.Commands.RegisterUser;
    using Catman.Education.Application.Features.User.Commands.UpdateUser;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUserCommand, User>();
            CreateMap<UpdateUserCommand, User>()
                .ForMember(user => user.Id, options => options.Ignore());
        }
    }
}
