using AnimalsService.Model;
using Sieve.Services;

namespace AnimalsService.Config.Sieve
{
  public class ContractSieveConfig : ISieveConfiguration
  {
    public void Configure(SievePropertyMapper mapper)
    {
      mapper.Property<Contract>(p => p.Id).CanSort().CanFilter();
      mapper.Property<Contract>(p => p.Num).CanSort().CanFilter();
      mapper.Property<Contract>(p => p.ConclusionDate).CanSort().CanFilter();
      mapper.Property<Contract>(p => p.CompletionDate).CanSort().CanFilter();
      mapper.Property<Contract>(p => p.Customer.Id).CanSort().CanFilter().HasName("customer");
      mapper.Property<Contract>(p => p.Contractor.Id).CanSort().CanFilter().HasName("contractor");
    }
  }
}
