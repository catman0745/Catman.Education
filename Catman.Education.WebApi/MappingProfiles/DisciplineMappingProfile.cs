namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Discipline.Commands.CreateDiscipline;
    using Catman.Education.Application.Features.Discipline.Commands.UpdateDiscipline;
    using Catman.Education.Application.Features.Discipline.Queries.GetDisciplines;
    using Catman.Education.WebApi.DataTransferObjects.Discipline;

    public class DisciplineMappingProfile : Profile
    {
        public DisciplineMappingProfile()
        {
            CreateMap<Discipline, DisciplineDto>();
            CreateMap<GetDisciplinesDto, GetDisciplinesQuery>();
            CreateMap<CreateDisciplineDto, CreateDisciplineCommand>();
            CreateMap<UpdateDisciplineDto, UpdateDisciplineCommand>();
        }
    }
}
