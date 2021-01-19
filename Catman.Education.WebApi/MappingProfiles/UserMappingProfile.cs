namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Features.User.Queries.GenerateToken;
    using Catman.Education.Application.Features.User.Queries.GetUsers;
    using Catman.Education.WebApi.DataTransferObjects.User;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<GetUsersDto, GetUsersQuery>();
            CreateMap<GenerateTokenDto, GenerateTokenQuery>();
            CreateMap<User, UserDto>();
        }
    }
}
