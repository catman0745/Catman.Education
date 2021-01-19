namespace Catman.Education.Application.Abstractions
{
    using Catman.Education.Application.Entities.Users;

    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
