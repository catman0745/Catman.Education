namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Student.Commands.RegisterStudent;
    using Catman.Education.Application.Features.Student.Commands.UpdateStudent;
    using Catman.Education.WebApi.DataTransferObjects.Student;

    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<RegisterStudentDto, RegisterStudentCommand>();
            CreateMap<UpdateStudentDto, UpdateStudentCommand>();
        }
    }
}