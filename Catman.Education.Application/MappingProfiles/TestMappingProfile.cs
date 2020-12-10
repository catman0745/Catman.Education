namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Test.Commands.CreateTest;
    using Catman.Education.Application.Features.Test.Commands.UpdateTest;

    public class TestMappingProfile : Profile
    {
        public TestMappingProfile()
        {
            CreateMap<CreateTestCommand, Test>();
            CreateMap<UpdateTestCommand, Test>()
                .ForMember(test => test.Id, options => options.Ignore());
        }
    }
}
