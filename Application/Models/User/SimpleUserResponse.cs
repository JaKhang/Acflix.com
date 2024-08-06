using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.SimpleUser
{
    public record SimpleUserResponse
        (
        Guid id,
        string Name,
        string Avatar
        )
    {
    }
}
