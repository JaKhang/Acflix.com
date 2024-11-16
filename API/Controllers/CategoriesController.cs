using Application.Commands;
using Application.Commands.Category;
using Application.Models.Base;
using Application.Models.Category;
using Application.Models.Film;
using Application.Queries;
using Application.Queries.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController(ISender sender) : ControllerBase
    {

        [HttpGet]
        public async Task<Page<CategoryResponse>> GetAllCategory(int offset = 0, int limit = 20, string sort = "")
        {
            return await sender.Send(new FindAllCategoriesQuery(offset, limit));
        }

        [HttpGet("{id}/films")]
        public async Task<Page<FilmResponse>> GetFilmsByCategory(string id, int offset = 0, int limit = 20, string sort = "")
        {
            return await sender.Send(new FindFilmsByCategoryIdQuery(Guid.Parse(id), offset, limit));
        }

        [HttpPost("")]
        public async Task<Guid> PostCategory([FromBody] CategoryRequest request)
        {
            var id = await sender.Send(new CreateCategoryCommand(request.Name, request.CoverId, request.FilmsIds,
                request.Popularity));
            return id;
        }




    }
}
