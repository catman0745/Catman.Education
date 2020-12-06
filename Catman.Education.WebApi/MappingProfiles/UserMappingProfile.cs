namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Features.User.Queries.GenerateToken;
    using Catman.Education.WebApi.DataTransferObjects.User;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<GenerateTokenDto, GenerateTokenQuery>();
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.Role, options => options.MapFrom(user => user.Role().ToString()));
        }
    }
}
