namespace Catman.Education.WebApi.MappingProfiles
{
    using AutoMapper;
    using Catman.Education.Application.Pagination;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;

    public class PaginationMappingProfile : Profile
    {
        public PaginationMappingProfile()
        {
            CreateMap<PaginationInfoDto, PaginationInfo>();
            CreateMap(typeof(Paginated<>), typeof(PaginatedDto<>));
        }
    }
}
