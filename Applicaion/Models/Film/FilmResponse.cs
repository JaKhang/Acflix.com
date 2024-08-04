using Applicaion.Models.Actor;
using Applicaion.Models.Genre;
using Applicaion.Models.Image;
using Applicaion.Models.FilmType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaion.Models.Film
{
    public record FilmResponse
        (
            Guid Id,
            string Name,
            string OriginnalName,
            string Description,
            List<GenreResponse> Genres,
            string Director,
            List<ActorResponse> Actors,
            string Country,
            int Duration,
            string ReleaseDate,
            string ReleaseDatePrecision,
            List<FilmTypeResponse> Types,
            int Restriction,
            List<ImageResponse> Poster,
            List<ImageResponse> Cover,
            string Status,
            string Language,
            int Episodes,
            int LastEpisodes
        )
    {
    }
}
