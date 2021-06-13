namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Features.Teacher.Commands.RegisterTeacher;
    using Catman.Education.Application.Features.Teacher.Commands.UpdateTeacher;

    public class TeacherMappingProfile : Profile
    {
        public TeacherMappingProfile()
        {
            CreateMap<RegisterTeacherCommand, Teacher>();
            CreateMap<UpdateTeacherCommand, Teacher>()
                .ForMember(teacher => teacher.Id, options => options.Ignore());
        }
    }
}
