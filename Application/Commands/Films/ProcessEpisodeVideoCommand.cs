using Microsoft.AspNetCore.Http;

namespace Application.Commands.Films;

public record ProcessEpisodeVideoCommand(IFormFile Src, Guid EpisodeId);