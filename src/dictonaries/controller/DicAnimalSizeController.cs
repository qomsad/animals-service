using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsService.Controller
{
  [Authorize]
  [Route("dic_animal_size")]
  [ApiController]
  public class DicAnimalSizeController(DicAnimalSizeService service)
    : DictBaseController<DicAnimalSize>(service) { }
}
