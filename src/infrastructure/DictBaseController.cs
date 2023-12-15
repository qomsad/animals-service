using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Infrastructure
{
  public class DictBaseController<T>(DictBaseService<T> _service) : ControllerBase
  {
    protected readonly DictBaseService<T> service = _service;

    [HttpGet]
    public IActionResult GetAll()
    {
      IEnumerable<T> data = service.GetAll();
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
  }
}
