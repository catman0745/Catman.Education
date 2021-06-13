namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Features.User.Queries.GenerateToken;
    using Catman.Education.Application.Models.Auth;
    using Catman.Education.WebApi.DataTransferObjects.Admin;
    using Catman.Education.WebApi.DataTransferObjects.Student;
    using Catman.Education.WebApi.DataTransferObjects.Teacher;
    using Catman.Education.WebApi.DataTransferObjects.User;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<GenerateTokenDto, GenerateTokenQuery>();
            CreateMap<User, UserDto>()
                .Include<Admin, AdminDto>()
                .Include<Student, StudentDto>()
                .Include<Teacher, TeacherDto>();

            CreateMap<UserInfo, UserInfoDto>();
        }
    }
}
