using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("legal_type")]
  [ApiController]
  public class LegalTypeController(LegalTypeService service)
    : DictBaseController<LegalType>(service) { }
}
