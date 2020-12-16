namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Test.Commands.CreateTest;
    using Catman.Education.Application.Features.Test.Commands.UpdateTest;
    using Catman.Education.Application.Results.Testing;

    public class TestMappingProfile : Profile
    {
        public TestMappingProfile()
        {
            CreateMap<TestCheckResult, TestingResult>();
            CreateMap<CreateTestCommand, Test>();
            CreateMap<UpdateTestCommand, Test>()
                .ForMember(test => test.Id, options => options.Ignore());
        }
    }
}
