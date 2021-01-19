namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Features.Student.Commands.RegisterStudent;
    using Catman.Education.Application.Features.Student.Commands.UpdateStudent;
    using Catman.Education.Application.Features.Student.Queries.GetStudents;
    using Catman.Education.WebApi.DataTransferObjects.Student;

    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<GetStudentsDto, GetStudentsQuery>();
            CreateMap<RegisterStudentDto, RegisterStudentCommand>();
            CreateMap<UpdateStudentDto, UpdateStudentCommand>();
        }
    }
}
