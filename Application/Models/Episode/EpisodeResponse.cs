using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Episode
{
    public record EpisodeResponse
        (
        Guid Id,
        int Index,
        string Label,
        string Name,
        Guid SourceId
        )
    {
    }
}
