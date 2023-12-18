using AnimalsService.Infrastructure;
using AnimalsService.Model;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("catch_acts")]
  [ApiController]
  public class CatchActController(CatchActService service)
    : BaseController<CatchAct>(service) { }
}
