using Domain.Film.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {

        // GET: /api/v1/films
        [HttpGet]
        public IEnumerable<string> Get(ISet<Guid> Ids)
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/<FilmController>/5
        // https://localhost//api/v1/films/{id}
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            Film film;
            return "value";
        }

        // POST api/<FilmController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FilmController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
