using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Films;

public record AddNewEpisodeCommand(Guid SeriesId,string Name, string Label) : IRequest<Guid>;