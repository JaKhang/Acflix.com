using Application.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Base
{
    public record Page<T>
        (
        int TotalItems,
        List<T> Items,
        bool IsFirst,
        bool IsLast,
        int Current,
        int Limit,
        int TotalPage
        )
    {
    }
}
