using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicAnimalHairService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicAnimalHair>(context, sieve)
  {
    public override Pagination<DicAnimalHair> GetAll(SieveModel param)
    {
      IEnumerable<DicAnimalHair> data = sieve.Apply(param, context.AnimalHair);
      int total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.AnimalHair).Count();
      return new Pagination<DicAnimalHair> { Data = data, Total = total };
    }

    public override DicAnimalHair? GetOne(long id)
    {
      return context.AnimalHair.FirstOrDefault(e => e.Id == id);
    }
  }
}
