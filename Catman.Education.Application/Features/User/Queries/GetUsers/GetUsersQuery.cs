namespace Catman.Education.Application.Features.User.Queries.GetUsers
{
    using System.Collections.Generic;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Results;
    using MediatR;

    public class GetUsersQuery : IRequest<ResourceRequestResult<ICollection<User>>>
    {
        public string Username { get; set; }
        
        public string Role { get; set; }
    }
}
