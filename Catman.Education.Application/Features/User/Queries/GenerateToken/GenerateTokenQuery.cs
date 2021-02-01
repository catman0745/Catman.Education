namespace Catman.Education.Application.Features.User.Queries.GenerateToken
{
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GenerateTokenQuery : IRequest<ResourceRequestResult<string>>
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
    }
}
