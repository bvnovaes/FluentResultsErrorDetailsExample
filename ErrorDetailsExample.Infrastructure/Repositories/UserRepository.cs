using ErrorDetailsExample.Domain.Users;
using FluentResults;

namespace ErrorDetailsExample.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private static List<User> _users = [];

    public Result<User> GetUserById(long id)
    {
        User? user = _users.FirstOrDefault(x => x.Id == id);

        return user is not null
            ? Result.Ok(user)
            : Result.Fail(new Error("Usuário não encontrado").WithMetadata("NotFound", true));
    }

    public Result<List<User>> GetAllUsers()
    {
        return _users;
    }

    public Result<User> AddUser(User user)
    {
        if (_users.Any(x => x.Id == user.Id))
        {
            return Result.Fail(new Error("Usuário já existe").WithMetadata("Conflict", true));
        }

        _users.Add(user);
        return user;
    }

    public Result<User> UpdateUser(User user)
    {
        User? existingUser = _users.FirstOrDefault(u => u.Id == user.Id);

        if (existingUser is null)
        {
            return Result.Fail(new Error("Usuário não encontrado").WithMetadata("NotFound", true));
        }

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.SubscriptionType = user.SubscriptionType;

        return existingUser;
    }

    public Result<User> DeleteUser(long id)
    {
        User? existingUser = _users.FirstOrDefault(u => u.Id == id);
        if (existingUser is null)
        {
            return Result.Fail(new Error("Usuário não encontrado").WithMetadata("NotFound", true));
        }

        _users.Remove(existingUser);
        return existingUser;
    }
}