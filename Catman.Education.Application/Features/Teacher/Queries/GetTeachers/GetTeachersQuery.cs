namespace Catman.Education.Application.Features.Teacher.Queries.GetTeachers
{
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Pagination;
    using MediatR;

    public class GetTeachersQuery : PaginationInfo, IRequest<ResourceRequestResult<Paginated<Teacher>>>
    {
    }
}
