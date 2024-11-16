using Domain.Base.ValueObjects;

namespace Application.Models.Image;

public record ImageResponse(IEnumerable<VarientResponse> Variants, Guid Id, string Name)
{
    
}