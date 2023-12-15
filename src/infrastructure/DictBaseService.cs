using AnimalsService.Config;

namespace AnimalsService.Infrastructure
{
  public abstract class DictBaseService<T>(ApplicationContext _context)
  {
    protected readonly ApplicationContext context = _context;

    public abstract IEnumerable<T> GetAll();
    public abstract T? GetOne(long id);
  }
}
