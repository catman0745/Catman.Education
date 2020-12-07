namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net.Mime;
    using System.Security.Claims;
    using Catman.Education.WebApi.Responses;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected static ResourceSuccessResponse<TResource> Success<TResource>(string message, TResource resource) =>
            new (message, resource);

        protected static Response Success(string message) =>
            new (success: true, message);
        
        protected Guid UserId => new (GetUserClaim(JwtRegisteredClaimNames.Sub).Value);

        protected Claim GetUserClaim(string claimType) =>
            User.Claims.Single(claim => claim.Type == claimType);
    }
}
