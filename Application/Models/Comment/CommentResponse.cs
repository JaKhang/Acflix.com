using Application.Models.SimpleUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Comment
{
    public record CommentResponse
        (
        string Content,
        SimpleUserResponse User,
        int CreatedAt
        )
    {
    }
}
