using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AnimalsService.Config
{
  public class AuthOptions
  {
    public const string ISSUER = "animals_service";
    public const string AUDIENCE = "animals_front";
    private const string KEY = "CFAEAE2D650A6CA9862575DE54371EA980643849";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
      new(Encoding.UTF8.GetBytes(KEY));
  }
}
