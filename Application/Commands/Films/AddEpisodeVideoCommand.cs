using MediatR;

namespace Application.Commands.Films;

public record AddEpisodeVideoCommand(Guid FilmId, string Reference, int Duration, int Quality, bool Process) : IRequest;