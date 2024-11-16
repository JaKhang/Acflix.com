using Application.Models.Base;
using Application.Models.Comment;
using MediatR;

namespace Application.Queries.Comments;

public record FilmCommentQuery(Guid FilmId, int Offset, int Limit) : IRequest<Page<CommentResponse>>;