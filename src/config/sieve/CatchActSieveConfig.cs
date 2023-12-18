using AnimalsService.Model;
using Sieve.Services;

namespace AnimalsService.Config.Sieve
{
  public class CatchActSieveConfig : ISieveConfiguration
  {
    public void Configure(SievePropertyMapper mapper)
    {
      mapper.Property<CatchAct>(p => p.Id).CanSort().CanFilter();
      mapper.Property<CatchAct>(p => p.Num).CanSort().CanFilter();
      mapper.Property<CatchAct>(p => p.CatchDate).CanSort().CanFilter();
      mapper.Property<CatchAct>(p => p.CatchReason).CanSort().CanFilter();
      mapper.Property<CatchAct>(p => p.Municipality.Id).CanSort().CanFilter().HasName("municipality");
      mapper.Property<CatchAct>(p => p.Contract.Id).CanSort().CanFilter().HasName("contract");
    }
  }
}
