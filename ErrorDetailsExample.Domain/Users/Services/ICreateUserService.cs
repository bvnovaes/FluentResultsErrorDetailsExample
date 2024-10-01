using FluentResults;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface ICreateUserService
{
    Result<User> CreateUser(User user);
}