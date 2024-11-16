using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Vote
{
    public record VoteResponse(int Count,double Average,int User)
    {
    }
}
