using MediatR;

namespace Application.Commands.Films;

public record HideFilmCommand(Guid FilmId) : IRequest;