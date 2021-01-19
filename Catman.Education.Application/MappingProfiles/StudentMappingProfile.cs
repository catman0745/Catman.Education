namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Features.Student.Commands.RegisterStudent;
    using Catman.Education.Application.Features.Student.Commands.UpdateStudent;

    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<RegisterStudentCommand, Student>();
            CreateMap<UpdateStudentCommand, Student>()
                .ForMember(student => student.Id, options => options.Ignore());
        }
    }
}
