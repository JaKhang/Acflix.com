using Application.Models.Base;
using Application.Models.Category;
using Application.Models.Episode;
using Application.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface ICategoryQueries
    {
        Task<IEnumerable<CategoryResponse>> FindAll(PageRequest pageRequest);

        Task<IEnumerable<FilmResponse>> FindFilmsById(Guid categoryId, PageRequest pageRequest);

    }
}
