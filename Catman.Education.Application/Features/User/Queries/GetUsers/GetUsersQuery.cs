namespace Catman.Education.Application.Features.User.Queries.GetUsers
{
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;
    using MediatR;

    public class GetUsersQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<User>>>
    {
        public string Username { get; set; }
        
        public string Role { get; set; }
    }
}
