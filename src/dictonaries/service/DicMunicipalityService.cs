using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicMunicipalityService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicMunicipality>(context, sieve)
  {
    public override Pagination<DicMunicipality> GetAll(SieveModel param)
    {
      IEnumerable<DicMunicipality> data = sieve.Apply(param, context.Municipalities);
      int Total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.Municipalities).Count();
      return new Pagination<DicMunicipality> { Data = data, Total = Total };
    }

    public override DicMunicipality? GetOne(long id)
    {
      return context.Municipalities.FirstOrDefault(e => e.Id == id);
    }
  }
}
