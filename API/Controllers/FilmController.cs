using Domain.Film.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmController : ControllerBase
    {

        // GET: /api/v1/films
        [HttpGet]
        public IEnumerable<string> Get(ISet<Guid> Ids)
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/films/{id}
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/films
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/films/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/films/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
