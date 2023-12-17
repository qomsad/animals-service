using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("dic_organization_type")]
  [ApiController]
  public class DicOrganizationTypeController(DicOrganizationTypeService service)
    : DictBaseController<DicOrganizationType>(service) { }
}
