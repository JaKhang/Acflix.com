namespace Application.Models.User;

public record UserProfileResponse(string Email, string Name, bool Verified, DateOnly DateOfBirth, IEnumerable<string> Roles);