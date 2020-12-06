namespace Catman.Education.Application.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Admin.Commands.RegisterAdmin;
    using Catman.Education.Application.Features.Admin.Commands.UpdateAdmin;

    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            CreateMap<RegisterAdminCommand, Admin>();
            CreateMap<UpdateAdminCommand, Admin>()
                .ForMember(admin => admin.Id, options => options.Ignore());
        }
    }
}
