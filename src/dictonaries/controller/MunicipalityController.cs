using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("municipalities")]
  [ApiController]
  public class MunicipalityController(MunicipalityService service)
    : DictBaseController<Municipality>(service) { }
}
