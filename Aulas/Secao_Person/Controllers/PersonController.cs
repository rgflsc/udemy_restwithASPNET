using Microsoft.AspNetCore.Mvc;
using Secao_Person.Business;
using Secao_Person.Model;

namespace Secao_Person.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private IPersonBusiness _personService;
        public PersonController(IPersonBusiness personService) => _personService = personService;

        // GET: api/Person
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST: api/Person
        [HttpPost]
        public IActionResult Post([FromBody] PersonModel person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT: api/Person
        [HttpPut]
        public IActionResult Put([FromBody] PersonModel person)
        {
            if (person == null) return BadRequest();
            var updatePerson = _personService.Update(person);
            if (updatePerson == null) return BadRequest();
            return new ObjectResult(updatePerson);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
