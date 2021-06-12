namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Auth;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserInfo>();
        }
    }
}
