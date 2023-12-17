using AnimalsService.Infrastructure;
using AnimalsService.Model;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("contracts")]
  [ApiController]
  public class ContractController(ContractService service) : BaseController<Contract>(service) { }
}
