namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Features.Teacher.Commands.RegisterTeacher;
    using Catman.Education.Application.Features.Teacher.Commands.UpdateTeacher;
    using Catman.Education.Application.Features.Teacher.Queries.GetTeachers;
    using Catman.Education.WebApi.DataTransferObjects.Teacher;

    public class TeacherMappingProfile : Profile
    {
        public TeacherMappingProfile()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<GetTeachersDto, GetTeachersQuery>();
            CreateMap<RegisterTeacherDto, RegisterTeacherCommand>();
            CreateMap<UpdateTeacherDto, UpdateTeacherCommand>();
        }
    }
}
