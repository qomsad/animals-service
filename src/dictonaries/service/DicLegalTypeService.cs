using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicLegalTypeService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicLegalType>(context, sieve)
  {
    public override Pagination<DicLegalType> GetAll(SieveModel param)
    {
      IEnumerable<DicLegalType> data = sieve.Apply(param, context.LegalTypes);
      int Total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.LegalTypes).Count();
      return new Pagination<DicLegalType> { Data = data, Total = Total };
    }

    public override DicLegalType? GetOne(long id)
    {
      return context.LegalTypes.FirstOrDefault(e => e.Id == id);
    }
  }
}
