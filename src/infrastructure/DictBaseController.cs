using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace AnimalsService.Infrastructure
{
  public class DictBaseController<T>(DictBaseService<T> _service) : ControllerBase
  {
    protected readonly DictBaseService<T> service = _service;

    [HttpGet]
    public IActionResult GetAll([FromQuery] SieveModel param)
    {
      Pagination<T> result = service.GetAll(param);
      IEnumerable<T> data = result.Data;
      int total = result.Total;
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
  }
}
