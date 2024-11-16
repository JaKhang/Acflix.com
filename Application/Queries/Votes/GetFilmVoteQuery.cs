using Application.Models.Vote;
using MediatR;

namespace Application.Queries.Votes;

public record GetFilmVoteQuery(Guid FilmId, Guid? UserId) : IRequest<VoteResponse>;