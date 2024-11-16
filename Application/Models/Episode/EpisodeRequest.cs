using Microsoft.AspNetCore.Http;

namespace Application.Models.Episode;

public record EpisodeRequest(IFormFile? Src, string Name, string Label);