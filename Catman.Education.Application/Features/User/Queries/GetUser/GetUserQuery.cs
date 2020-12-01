namespace Catman.Education.Application.Features.User.Queries.GetUser
{
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.RequestResults;
    using MediatR;

    public class GetUserQuery : IRequest<ResourceRequestResult<User>>
    {
        public string Username { get; }

        public GetUserQuery(string username)
        {
            Username = username;
        }
    }
}
