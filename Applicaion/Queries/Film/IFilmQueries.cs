using Applicaion.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaion.Queries.Film
{
    public interface IFilmQueries
    {
        Task<FilmResponse> FindFilmById(Guid filmId);

        Task<FilmResponse> FindFilmByIds(ISet<Guid> ids);
    }
}
