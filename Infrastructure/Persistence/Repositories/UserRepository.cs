using Domain.Base.ValueObjects;
using Domain.User.Entities;
using Domain.User.Repositories;
using Infrastructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{


    public async Task<User> SaveAsync(User user)
    {
        if (await context.Users.ContainsAsync(user))
        {
            user = context.Users.Update(user).Entity;
        }
        else
        {
           user = context.Users.Add(user).Entity;
        }

        _ = await context.SaveChangesAsync();
        return user;
    }

    public Code Save(Code code)
    {
        throw new NotImplementedException();

    }

    public Task<User> FindByIdAsync(Id id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await context.Users
            .Where(user => user.Email == email)
            .Include(user => user.Codes)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> ExistByEmail(string email)
    {
        var count = await context.Users.Where(u => u.Email == email).CountAsync();
        return count > 0;
    }
}