using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("dic_municipality")]
  [ApiController]
  public class DicMunicipalityController(DicMunicipalityService service)
    : DictBaseController<DicMunicipality>(service) { }
}
