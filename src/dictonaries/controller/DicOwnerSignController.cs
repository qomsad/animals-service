using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("dic_owner_sign")]
  [ApiController]
  public class DicOwnerSignController(DicOwnerSignService service)
    : DictBaseController<DicOwnerSign>(service) { }
}
