using Application.Models.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Category
{
    public record CategoryResponse(Guid Id, string Name, List<ImageResponse> Icons)
    {

    }
}
