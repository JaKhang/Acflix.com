using Application.Models.Base;
using Application.Models.Comment;
using Application.Models.SimpleUser;
using Domain.Base.ValueObjects;
using Domain.User.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Queries.Comments;

public class CommentQueryHandler(DatabaseContext context) : IRequestHandler<FilmCommentQuery, Page<CommentResponse>>
{
    public async Task<Page<CommentResponse>> Handle(FilmCommentQuery request, CancellationToken cancellationToken)
    {
        var query = from comment in context.Comments
            where comment.FilmId == new Id(request.FilmId)
            select new
            {
                Comment = comment,
                User = (from user in context.Users
                    select user).First()
            };

        var count = await query.CountAsync(cancellationToken);
        var comments =await query.Skip(request.Offset).Take(request.Limit).Select(a  => new CommentResponse(a.Comment.Content, new SimpleUserResponse(a.User.Id.Value, a.User.Name.ToString(), ""), a.Comment.CreatedAt.ToString("hh:mm dd/MM/yyyy"))).AsNoTracking().ToListAsync(cancellationToken);
        return new Page<CommentResponse>(count, comments, request.Offset == 0, request.Offset + request.Limit >= count,
            request.Limit, request.Offset);
    }
}