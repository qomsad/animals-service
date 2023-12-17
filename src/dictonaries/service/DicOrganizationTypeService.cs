using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class DicOrganizationTypeService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<DicOrganizationType>(context, sieve)
  {
    public override Pagination<DicOrganizationType> GetAll(SieveModel param)
    {
      IEnumerable<DicOrganizationType> data = sieve.Apply(param, context.OrganizationTypes);
      int total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.OrganizationTypes).Count();
      return new Pagination<DicOrganizationType> { Data = data, Total = total };
    }

    public override DicOrganizationType? GetOne(long id)
    {
      return context.OrganizationTypes.FirstOrDefault(e => e.Id == id);
    }
  }
}
