using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("organization_type")]
  [ApiController]
  public class OrganizationTypeController(OrganizationTypeService service)
    : DictBaseController<OrganizationType>(service) { }
}
