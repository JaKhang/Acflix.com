using Application.Models.User;
using Azure.Core;
using MediatR;

namespace Application.Commands.Authentication;

public record AuthenticateCommand(string Email, string Password) : IRequest<AuthResponse>;