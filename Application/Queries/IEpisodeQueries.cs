using Application.Models.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IEpisodeQueries
    {
        Task<IEnumerable<EpisodeResponse>> FindEpisodeByFilmId(Guid filmId);

    }
}
