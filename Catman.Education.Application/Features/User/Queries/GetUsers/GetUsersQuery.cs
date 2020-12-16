namespace Catman.Education.Application.Features.User.Queries.GetUsers
{
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Pagination;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetUsersQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<User>>>
    {
        public string Username { get; set; }
        
        public string Role { get; set; }
    }
}
