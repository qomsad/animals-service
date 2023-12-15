using AnimalsService.Infrastructure;
using AnimalsService.Model;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("organization")]
  [ApiController]
  public class OrganizationController(OrganizationService service) : BaseController<Organization>(service) { }
}
