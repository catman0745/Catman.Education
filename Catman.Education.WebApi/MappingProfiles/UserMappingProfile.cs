namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.User.Commands;
    using Catman.Education.Application.Features.User.Queries;
    using Catman.Education.WebApi.DataTransferObjects.User;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUserDto, RegisterUserCommand>();
            CreateMap<GenerateTokenDto, GenerateTokenQuery>();
            CreateMap<UpdateUserDto, UpdateUserCommand>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserDto>();
        }
    }
}
