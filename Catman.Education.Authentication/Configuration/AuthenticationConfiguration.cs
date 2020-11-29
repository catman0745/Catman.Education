namespace Catman.Education.Authentication.Configuration
{
    using System.Text;
    using Microsoft.IdentityModel.Tokens;

    internal class AuthenticationConfiguration : IAuthenticationConfiguration
    {
        public SymmetricSecurityKey SymmetricSecurityKey =>
            new (Encoding.ASCII.GetBytes(SecurityKey));
        
        public string SecurityKey { get; init; }
        
        public string Issuer { get; init; }
        
        public string Audience { get; init; }
        
        public int TokenLifetime { get; init; }
    }
}
