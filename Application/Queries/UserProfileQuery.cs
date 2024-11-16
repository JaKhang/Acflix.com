using Application.Models.User;
using MediatR;

namespace Application.Queries;

public record UserProfileQuery(Guid UserId) : IRequest<UserProfileResponse>;