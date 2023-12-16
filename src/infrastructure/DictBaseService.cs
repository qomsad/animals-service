using AnimalsService.Config;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Infrastructure
{
  public abstract class DictBaseService<T>(ApplicationContext _context, ISieveProcessor _sieve)
  {
    protected readonly ApplicationContext context = _context;
    protected readonly ISieveProcessor sieve = _sieve;

    public abstract Pagination<T> GetAll(SieveModel param);
    public abstract T? GetOne(long id);
  }
}
