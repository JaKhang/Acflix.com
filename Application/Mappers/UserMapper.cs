using Application.Models.User;
using Domain.User.Entities;
using Domain.User.ObjectValue;

namespace Application.Mappers;

public class UserMapper
{
    public User Map(RegisterRequest request)
    {
        return User.builder()
            .FirstName(request.FirstName)
            .LastName(request.LastName)
            .Email(request.LastName)
            .Password(BCrypt.Net.BCrypt.HashPassword(request.Password))
            .Birthday(request.DateOfBirth)
            .PhoneNumber(request.PhoneNumber)
            .Provider(UserProvider.ACFLIX)
            .Roles(Role.USER)
            .build();

    }

}