using Domain.Image.ValueObjects;

namespace Infrastructure.Media;

public record ImageProcessResult(Dimension Dimension, string Reference)
{
    
}