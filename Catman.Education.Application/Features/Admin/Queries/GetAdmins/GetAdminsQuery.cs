namespace Catman.Education.Application.Features.Admin.Queries.GetAdmins
{
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;
    using MediatR;

    public class GetAdminsQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<Admin>>>
    {
    }
}
