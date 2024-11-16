using Application.Models.Film;

namespace Application.Models.Category;

public record CategoryDetailsResponse(Guid Id, string Name, IEnumerable<FilmResponse> Films)
{

}