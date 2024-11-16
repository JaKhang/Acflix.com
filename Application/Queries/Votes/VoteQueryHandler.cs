using Application.Models.Vote;
using Domain.Base.ValueObjects;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Votes;

public class VoteQueryHandler(DatabaseContext context) : IRequestHandler<GetFilmVoteQuery, VoteResponse>
{
    public async Task<VoteResponse> Handle(GetFilmVoteQuery request, CancellationToken cancellationToken)
    {
        var count = await context.Votes.Where(v => v.FilmId == new Id(request.FilmId)).CountAsync(cancellationToken);
        var avg = await context.Votes.Where(v => v.FilmId == new Id(request.FilmId))
            .AverageAsync(v => v.Score, cancellationToken);
        var userCore = 0;
        if (request.UserId is not null)
        {
            userCore = await context.Votes.Where(v => v.UserId == new Id(request.UserId.Value)).Select(v => v.Score)
                .FirstOrDefaultAsync(cancellationToken);
        }

        return new VoteResponse(count, avg, userCore);
    }
}