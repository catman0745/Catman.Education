namespace Catman.Education.Authentication.Configuration
{
    using Microsoft.IdentityModel.Tokens;

    internal interface IAuthenticationConfiguration
    {
        SymmetricSecurityKey SymmetricSecurityKey { get; }
        
        string Issuer { get; }
        
        string Audience { get; }
        
        int TokenLifetime { get; }
    }
}
