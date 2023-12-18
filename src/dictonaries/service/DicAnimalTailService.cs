using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicAnimalTailService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicAnimalTail>(context, sieve)
  {
    public override Pagination<DicAnimalTail> GetAll(SieveModel param)
    {
      IEnumerable<DicAnimalTail> data = sieve.Apply(param, context.AnimalTails);
      int total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.AnimalTails).Count();
      return new Pagination<DicAnimalTail> { Data = data, Total = total };
    }

    public override DicAnimalTail? GetOne(long id)
    {
      return context.AnimalTails.FirstOrDefault(e => e.Id == id);
    }
  }
}
