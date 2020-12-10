namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Discipline.Commands.CreateDiscipline;
    using Catman.Education.Application.Features.Discipline.Commands.UpdateDiscipline;

    public class DisciplineMappingProfile : Profile
    {
        public DisciplineMappingProfile()
        {
            CreateMap<CreateDisciplineCommand, Discipline>();
            CreateMap<UpdateDisciplineCommand, Discipline>()
                .ForMember(discipline => discipline.Id, options => options.Ignore());
        }
    }
}
