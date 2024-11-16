using Application.Models.Film;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Films;

public record CreateFilmCommand(
    string Name,
    string OriginalName,
    string Description,
    string Language,
    string OriginalLanguage,
    int AgeRestriction,
    string Country,
    int Popularity,
    DateTime ReleaseDate,
    string Precision,
    string FilmStatus,
    Guid DirectorId,
    Guid PosterId,
    Guid CoverId,
    IEnumerable<Guid> ActorIds,
    IEnumerable<Guid> RelatedFilms,
    IEnumerable<string> Genres,
    int? Total,
    int? Duration,
    string FilmType
) : IRequest<Guid>;