namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.User.Commands.RegisterUser;
    using Catman.Education.Application.Features.User.Commands.UpdateUser;
    using Catman.Education.Application.Features.User.Queries.GenerateToken;
    using Catman.Education.WebApi.DataTransferObjects.User;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUserDto, RegisterUserCommand>();
            CreateMap<GenerateTokenDto, GenerateTokenQuery>();
            CreateMap<UpdateUserDto, UpdateUserCommand>();
            CreateMap<User, UserDto>();
        }
    }
}
