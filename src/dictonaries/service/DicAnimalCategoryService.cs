using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicAnimalCategoryService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicAnimalCategory>(context, sieve)
  {
    public override Pagination<DicAnimalCategory> GetAll(SieveModel param)
    {
      IEnumerable<DicAnimalCategory> data = sieve.Apply(param, context.AnimalCategories);
      int total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.AnimalCategories).Count();
      return new Pagination<DicAnimalCategory> { Data = data, Total = total };
    }

    public override DicAnimalCategory? GetOne(long id)
    {
      return context.AnimalCategories.FirstOrDefault(e => e.Id == id);
    }
  }
}
