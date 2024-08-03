using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaion.Models.Error
{
    public record ErrorResponse
        (
        int Status,
        string Message
        )
    {
    }
}
