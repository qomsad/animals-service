using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicAnimalEarsService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicAnimalEars>(context, sieve)
  {
    public override Pagination<DicAnimalEars> GetAll(SieveModel param)
    {
      IEnumerable<DicAnimalEars> data = sieve.Apply(param, context.AnimalEars);
      int total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.AnimalEars).Count();
      return new Pagination<DicAnimalEars> { Data = data, Total = total };
    }

    public override DicAnimalEars? GetOne(long id)
    {
      return context.AnimalEars.FirstOrDefault(e => e.Id == id);
    }
  }
}
