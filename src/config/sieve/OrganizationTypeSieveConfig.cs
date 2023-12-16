using AnimalsService.Dictionary;
using AnimalsService.Model;
using Sieve.Services;

namespace AnimalsService.Config.Sieve
{
  public class OrganizationTypeSieveConfig : ISieveConfiguration
  {
    public void Configure(SievePropertyMapper mapper)
    {
      mapper.Property<OrganizationType>(p => p.Id).CanSort().CanFilter();
      mapper.Property<OrganizationType>(p => p.Value).CanSort().CanFilter();
    }
  }
}
