namespace Catman.Education.Authentication.Extensions
{
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using Microsoft.IdentityModel.Tokens;

    internal static class TokenHandlerExtensions
    {
        public static JwtSecurityTokenHandler JwtSecurityTokenHandler(
            this IEnumerable<ISecurityTokenValidator> securityTokenValidators) =>
            securityTokenValidators.OfType<JwtSecurityTokenHandler>().Single();
        
        /// <summary> Turns off default claim type mappings </summary>
        public static void ConfigureTokenHandler(this JwtSecurityTokenHandler tokenHandler)
        {
            // Deals with "sub" -> "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier" and others
            
            tokenHandler.InboundClaimTypeMap.Clear();
            tokenHandler.OutboundClaimTypeMap.Clear();
        }
    }
}
