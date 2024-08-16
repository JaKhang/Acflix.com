using Application.Models.Image;
using Domain.Image.Entities;

namespace Application.Mappers;

public class ImageMapper
{
    private const string ImageUrl = "http://localhost:9000/image/";

    public ImageResponse map(Image image)
    {
        var variants = image.Variants.Select(v => new VarientResponse(ImageUrl + v.Reference, v.Dimension.Width, v.Dimension.Height));

        return new ImageResponse(variants, image.Id, image.Name);
    }
}