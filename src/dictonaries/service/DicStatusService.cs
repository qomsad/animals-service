using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicStatusService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicStatus>(context, sieve)
  {
    public override Pagination<DicStatus> GetAll(SieveModel param)
    {
      IEnumerable<DicStatus> data = sieve.Apply(param, context.Statuses);
      int total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.Statuses).Count();
      return new Pagination<DicStatus> { Data = data, Total = total };
    }

    public override DicStatus? GetOne(long id)
    {
      return context.Statuses.FirstOrDefault(e => e.Id == id);
    }
  }
}
