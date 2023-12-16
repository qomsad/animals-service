using AnimalsService.Config.Sieve;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Config
{
  public class ApplicationSieveProcessor(IOptions<SieveOptions> options) : SieveProcessor(options)
  {
    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
      mapper.ApplyConfiguration<OrganizationSieveConfig>();
      mapper.ApplyConfiguration<OrganizationTypeSieveConfig>();
      mapper.ApplyConfiguration<LegalTypeSieveConfig>();
      return mapper;
    }
  }
}
