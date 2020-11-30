namespace Catman.Education.WebApi.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected Guid UserId => new (GetUserClaim(JwtRegisteredClaimNames.Sub).Value);

        protected Claim GetUserClaim(string claimType) =>
            User.Claims.Single(claim => claim.Type == claimType);
    }
}
