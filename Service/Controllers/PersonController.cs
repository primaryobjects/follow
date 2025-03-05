using Microsoft.AspNetCore.Mvc;
using Service.Managers;
using Service.Types;

namespace Followers2.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var persons = PersonManager.Load();
            return new JsonResult(persons);
        }

        [HttpGet("{id}")]
        public IActionResult Index(Guid id)
        {
            var person = PersonManager.Load(id);
            if (person != null)
            {
                return new JsonResult(person);
            }
            else
            {
                return NotFound("Error: Invalid PersonId.");
            }
        }

        [HttpPost()]
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                var result = PersonManager.Save(person);
                return new JsonResult(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}