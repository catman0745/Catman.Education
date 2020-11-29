namespace Catman.Education.Application.Interfaces
{
    using Catman.Education.Application.Entities;

    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
