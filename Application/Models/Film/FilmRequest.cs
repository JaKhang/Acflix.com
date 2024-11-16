using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Application.Models.Film
{        public record FilmRequest(
             [Required(ErrorMessage = "Film's name must not be null")] string Name,
             [Required(ErrorMessage = "Film's name must not be null")] string OriginalName,
             string Description,
             [Required(ErrorMessage = "Film's Language must not be null")] string Language,
             [Required(ErrorMessage = "Film's Original Language must not be null")] string OriginalLanguage,
             [Required(ErrorMessage = "Film's Age Restriction must not be null")] int AgeRestriction,
             string Country,
             int Popularity,
             [Required, DataType(DataType.DateTime)] DateTime ReleaseDate,
             string Precision,
             string FilmStatus,
             Guid DirectorId,
             IEnumerable<Guid>? ActorIds,
             IEnumerable<Guid>? RelatedFilms,
             IEnumerable<string> Genres,
             int? Total,
             int? Duration,
             string FilmType,
             IFormFile Poster,
             IFormFile Cover
         );

}