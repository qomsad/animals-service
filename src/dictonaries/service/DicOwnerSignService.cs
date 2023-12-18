using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicOwnerSignService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicOwnerSign>(context, sieve)
  {
    public override Pagination<DicOwnerSign> GetAll(SieveModel param)
    {
      IEnumerable<DicOwnerSign> data = sieve.Apply(param, context.OwnerSigns);
      int total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.OwnerSigns).Count();
      return new Pagination<DicOwnerSign> { Data = data, Total = total };
    }

    public override DicOwnerSign? GetOne(long id)
    {
      return context.OwnerSigns.FirstOrDefault(e => e.Id == id);
    }
  }
}
