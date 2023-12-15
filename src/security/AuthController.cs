using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AnimalsService.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AnimalsService.Security
{
  [Route("login")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    [HttpPost]
    public IActionResult Login([FromBody] LoginUser user)
    {
      List<Claim> claims = [new Claim(ClaimTypes.Name, user.Login)];
      JwtSecurityToken jwt =
        new(
          issuer: AuthOptions.ISSUER,
          audience: AuthOptions.AUDIENCE,
          claims: claims,
          expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
          signingCredentials: new SigningCredentials(
            AuthOptions.GetSymmetricSecurityKey(),
            SecurityAlgorithms.HmacSha256
          )
        );
      string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
      return Ok(new { access_token = encodedJwt, login = user.Login });
    }
  }
}
