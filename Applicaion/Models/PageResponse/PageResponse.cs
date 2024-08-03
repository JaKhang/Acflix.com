using Applicaion.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaion.Models.PageResponse
{
    public record PageResponse
        (
        int TotalItems,
        List<CommentResponse> items,
        Boolean IsFirst,
        Boolean IsLast,
        int Page,
        int Limit,
        int TotalPage
        )
    {
    }
}
