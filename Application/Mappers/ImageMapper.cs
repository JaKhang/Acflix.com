using Application.Models.Image;
using Domain.Image.Entities;

namespace Application.Mappers;

public class ImageMapper
{
    private const string ImageUrl = "https://d2a6-14-191-62-252.ngrok-free.app/image/";

    public static ImageResponse Map(Image image)
    {
        var variants = image.Variants.Select(v => new VarientResponse(ImageUrl + v.Reference, v.Dimension.Width, v.Dimension.Height));
        return new ImageResponse(variants, image.Id.Value, image.Name);
    }
}