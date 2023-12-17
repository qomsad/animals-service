using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class LegalTypeService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<LegalType>(context, sieve)
  {
    public override Pagination<LegalType> GetAll(SieveModel param)
    {
      IEnumerable<LegalType> data = sieve.Apply(param, context.LegalTypes);
      int Total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.LegalTypes).Count();
      return new Pagination<LegalType> { Data = data, Total = Total };
    }

    public override LegalType? GetOne(long id)
    {
      return context.LegalTypes.FirstOrDefault(e => e.Id == id);
    }
  }
}
