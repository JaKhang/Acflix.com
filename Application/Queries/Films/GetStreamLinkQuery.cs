using MediatR;

namespace Application.Queries.Films;

public record GetStreamLinkQuery(Guid FilmId) : IRequest<string>;
