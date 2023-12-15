using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;

namespace AnimalsService.Service
{
  public class OrganizationTypeService(ApplicationContext context) : DictBaseService<OrganizationType>(context)
  {
    public override IEnumerable<OrganizationType> GetAll()
    {
      return context.OrganizationTypes;
    }

    public override OrganizationType? GetOne(long id)
    {
      return context.OrganizationTypes.FirstOrDefault(e => e.Id == id);
    }
  }
}
