using Application.Commands;
using Application.Models.Base;
using Application.Models.Category;
using Application.Models.Film;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryQueries _categoryQueries;
        private readonly ICategoryCommands _categoryCommands;

        [HttpGet]
        public async Task<Page<CategoryResponse>> GetAllCategory(int offset = 0, int limit = 20, string sort = "")
        {
            return await _categoryQueries.FindAll(new PageRequest(offset, limit, sort));
        }

        [HttpGet("{id}/films")]
        public async Task<IEnumerable<FilmResponse>> GetFilmsByCategory(string id, int offset = 0, int limit = 20, string sort = "")
        {
            return await _categoryQueries.FindFilmsById(Guid.Parse(id), new PageRequest(offset, limit, sort));
        }

    }
}
