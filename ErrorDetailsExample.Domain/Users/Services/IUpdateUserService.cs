using FluentResults;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface IUpdateUserService
{
    Result<User> UpdateUser(User user);
}