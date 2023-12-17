using AnimalsService.Infrastructure;
using AnimalsService.Model;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("contract_costs")]
  [ApiController]
  public class ContractCostsController(ContractCostService service) : BaseController<ContractCost>(service) { }
}
