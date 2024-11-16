using Application.Models.Actor;
using Application.Models.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Base;

namespace Application.Models.Film
{
    public record FilmResponse
        (
            Guid Id,
            string Name,
            string OriginalName,
            string Description,
            List<string> Genres,
            string Director,
            List<SimpleObjectResponse> Actors,
            string Country,
            int Duration,
            string ReleaseDate,
            string ReleaseDatePrecision,
            string Type,
            int Restriction,
            IEnumerable<VarientResponse> Poster,
            IEnumerable<VarientResponse> Cover,
            string Status,
            string Language,
            int? Episodes,
            int? LastEpisodes,
            int? CurrentEpisodes,
            string OriginalLanguage

        )
    {
    }
}
