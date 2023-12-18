using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicAnimalSizeService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicAnimalSize>(context, sieve)
  {
    public override Pagination<DicAnimalSize> GetAll(SieveModel param)
    {
      IEnumerable<DicAnimalSize> data = sieve.Apply(param, context.AnimalSizes);
      int total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.AnimalSizes).Count();
      return new Pagination<DicAnimalSize> { Data = data, Total = total };
    }

    public override DicAnimalSize? GetOne(long id)
    {
      return context.AnimalSizes.FirstOrDefault(e => e.Id == id);
    }
  }
}
