using AnimalsService.Model;
using Sieve.Services;

namespace AnimalsService.Config.Sieve
{
  public class OrganizationSieveConfig : ISieveConfiguration
  {
    public void Configure(SievePropertyMapper mapper)
    {
      mapper.Property<Organization>(p => p.Id).CanSort().CanFilter();
      mapper.Property<Organization>(p => p.Address).CanSort().CanFilter();
      mapper.Property<Organization>(p => p.Name).CanSort().CanFilter();
      mapper.Property<Organization>(p => p.Inn).CanSort().CanFilter();
      mapper.Property<Organization>(p => p.Kpp).CanSort().CanFilter();
      mapper.Property<Organization>(p => p.OrganizationType.Id).CanSort().CanFilter().HasName("organizationType");
      mapper.Property<Organization>(p => p.LegalType.Id).CanSort().CanFilter().HasName("legalType");
    }
  }
}
