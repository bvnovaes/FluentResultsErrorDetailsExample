using FluentResults;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface IDeleteUserService
{
    Result<User> DeleteUser(long id);
}