using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Base
{
    public record PageRequest(int Offset, int Limit, string sort)
    {

    }
}
