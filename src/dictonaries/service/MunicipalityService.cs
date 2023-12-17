using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class MunicipalityService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<Municipality>(context, sieve)
  {
    public override Pagination<Municipality> GetAll(SieveModel param)
    {
      IEnumerable<Municipality> data = sieve.Apply(param, context.Municipalities);
      int Total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.Municipalities).Count();
      return new Pagination<Municipality> { Data = data, Total = Total };
    }

    public override Municipality? GetOne(long id)
    {
      return context.Municipalities.FirstOrDefault(e => e.Id == id);
    }
  }
}
