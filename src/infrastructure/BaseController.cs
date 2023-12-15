using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace AnimalsService.Infrastructure
{
  public abstract class BaseController<T>(BaseService<T> _service) : ControllerBase
  {
    private readonly BaseService<T> service = _service;

    [HttpPost]
    public IActionResult Create(T entity)
    {
      T result = service.Create(entity);
      return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      service.Delete(id);
      return Ok();
    }

    [HttpGet]
    public IActionResult GetList([FromQuery] SieveModel sieveModel)
    {
      IEnumerable<T> data = service.GetList(sieveModel);
      int total = data.Count();
      return Ok(new { data, total });
    }

    [HttpGet("{id}")]
    public IActionResult GetOne(long id)
    {
      T? entity = service.GetOne(id);

      if (entity == null)
      {
        return NotFound();
      }
      return Ok(entity);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, T entity)
    {
      T result = service.Update(id, entity);
      return Ok(result);
    }
  }
}
