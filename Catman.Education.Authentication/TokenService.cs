namespace Catman.Education.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Authentication.Configuration;
    using Microsoft.IdentityModel.Tokens;

    internal class TokenService : ITokenService
    {
        private static IEnumerable<Claim> UserClaims(User user)
        {
            yield return new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString());
            yield return new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role);
        }
        
        private readonly IAuthenticationConfiguration _configuration;
        private readonly SecurityTokenHandler _tokenHandler;
        private readonly SigningCredentials _signingCredentials;

        public TokenService(IAuthenticationConfiguration configuration)
        {
            _configuration = configuration;
            
            _signingCredentials =
                new SigningCredentials(configuration.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            
            _tokenHandler = new JwtSecurityTokenHandler();
        }
        
        public string GenerateToken(User user)
        {
            var token = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: UserClaims(user),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_configuration.TokenLifetime),
                signingCredentials: _signingCredentials
            );
            return _tokenHandler.WriteToken(token);
        }
    }
}
