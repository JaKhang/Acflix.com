using Application.Models.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Actor
{
    public record ActorResponse(Guid id,string name,List<VarientResponse> Images)

    {
    }
}
