using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;

namespace AnimalsService.Service
{
  public class LegalTypeService(ApplicationContext context) : DictBaseService<LegalType>(context)
  {
    public override IEnumerable<LegalType> GetAll()
    {
      return context.LegalTypes;
    }

    public override LegalType? GetOne(long id)
    {
      return context.LegalTypes.FirstOrDefault(e => e.Id == id);
    }
  }
}
