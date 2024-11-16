using Application.Exceptions;
using Application.Models.User;
using Domain.Base.ValueObjects;
using Domain.User.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Users;

public class UserQueryHandler(DatabaseContext databaseContext) : IRequestHandler<UserProfileQuery, UserProfileResponse>
{
    public async Task<UserProfileResponse> Handle(UserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await databaseContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(new Id(request.UserId)),
            cancellationToken: cancellationToken);
        if (user is null) throw new UserNotFoundException("");

        return new UserProfileResponse(
            user.Email,
            user.Name.ToString(),
            user.VerifiedAt is not null,
            user.Birthday ?? throw new Exception(),
            user.Roles.Select(r => r.Name)
        );
    }
}