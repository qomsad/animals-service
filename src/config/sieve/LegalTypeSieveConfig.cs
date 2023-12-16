using AnimalsService.Dictionary;
using AnimalsService.Model;
using Sieve.Services;

namespace AnimalsService.Config.Sieve
{
  public class LegalTypeSieveConfig : ISieveConfiguration
  {
    public void Configure(SievePropertyMapper mapper)
    {
      mapper.Property<LegalType>(p => p.Id).CanSort().CanFilter();
      mapper.Property<LegalType>(p => p.Value).CanSort().CanFilter();
    }
  }
}
