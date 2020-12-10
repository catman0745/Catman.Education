namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Test.Commands.CreateTest;
    using Catman.Education.Application.Features.Test.Commands.UpdateTest;
    using Catman.Education.Application.Features.Test.Queries.GetTests;
    using Catman.Education.WebApi.DataTransferObjects.Test;

    public class TestMappingProfile : Profile
    {
        public TestMappingProfile()
        {
            CreateMap<Test, TestDto>();
            CreateMap<GetTestsDto, GetTestsQuery>();
            CreateMap<CreateTestDto, CreateTestCommand>();
            CreateMap<UpdateTestDto, UpdateTestCommand>();
        }
    }
}
