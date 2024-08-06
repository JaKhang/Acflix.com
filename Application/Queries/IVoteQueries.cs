using Application.Models.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IVoteQueries
    {
        public Task<VoteResponse> FindVoteByIdAsync(Guid userId, Guid filmId);

    }
}
