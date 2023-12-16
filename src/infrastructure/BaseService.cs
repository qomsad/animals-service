using AnimalsService.Config;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Infrastructure
{
  public abstract class BaseService<T>(ApplicationContext _context, ISieveProcessor _sieve)
  {
    protected readonly ApplicationContext context = _context;
    protected readonly ISieveProcessor sieve = _sieve;

    public abstract T Create(T entity);
    public abstract void Delete(long id);
    public abstract bool Exists(long id);
    public abstract Pagination<T> GetList(SieveModel param);
    public abstract T? GetOne(long id);
    public abstract T Update(long id, T entity);
  }
}
