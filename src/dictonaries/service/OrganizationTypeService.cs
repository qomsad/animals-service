using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class OrganizationTypeService(ApplicationContext context, ISieveProcessor sieve)
    : DictBaseService<OrganizationType>(context, sieve)
  {
    public override Pagination<OrganizationType> GetAll(SieveModel param)
    {
      IEnumerable<OrganizationType> data = sieve.Apply(param, context.OrganizationTypes);
      int Total = sieve.Apply(new SieveModel { Filters = param.Filters }, context.OrganizationTypes).Count();
      return new Pagination<OrganizationType> { Data = data, Total = Total };
    }

    public override OrganizationType? GetOne(long id)
    {
      return context.OrganizationTypes.FirstOrDefault(e => e.Id == id);
    }
  }
}
