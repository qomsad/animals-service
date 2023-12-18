using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("dic_status")]
  [ApiController]
  public class DicStatusController(DicStatusService service)
    : DictBaseController<DicStatus>(service) { }
}
