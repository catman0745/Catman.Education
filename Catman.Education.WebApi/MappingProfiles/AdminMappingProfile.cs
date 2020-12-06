namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Features.Admin.Commands.RegisterAdmin;
    using Catman.Education.Application.Features.Admin.Commands.UpdateAdmin;
    using Catman.Education.WebApi.DataTransferObjects.Admin;

    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            CreateMap<Admin, AdminDto>();
            CreateMap<RegisterAdminDto, RegisterAdminCommand>();
            CreateMap<UpdateAdminDto, UpdateAdminCommand>();
        }
    }
}
