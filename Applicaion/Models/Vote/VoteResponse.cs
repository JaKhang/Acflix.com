using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaion.Models.Vote
{
    public record VoteResponse(int Count,int Average,int User)
    {
    }
}
