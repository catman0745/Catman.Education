namespace Catman.Education.Application.Features.User.Queries.GetUser
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GetUserQuery : IRequest<ResourceRequestResult<User>>
    {
        public Guid Id { get; }

        public GetUserQuery(Guid id)
        {
            Id = id;
        }
    }
}
