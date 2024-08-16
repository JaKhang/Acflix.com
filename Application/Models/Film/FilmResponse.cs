using Application.Models.Actor;
using Application.Models.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Film
{
    public record FilmResponse
        (
            Guid Id,
            string Name,
            string OriginnalName,
            string Description,
            List<string> Genres,
            string Director,
            List<ActorResponse> Actors,
            string Country,
            int Duration,
            string ReleaseDate,
            string ReleaseDatePrecision,
            string Type,
            int Restriction,
            List<VarientResponse> Poster,
            List<VarientResponse> Cover,
            string Status,
            string Language,
            int Episodes,
            int LastEpisodes
        )
    {
    }
}
