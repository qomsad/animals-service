using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("dic_legal_type")]
  [ApiController]
  public class DicLegalTypeController(DicLegalTypeService service)
    : DictBaseController<DicLegalType>(service) { }
}
