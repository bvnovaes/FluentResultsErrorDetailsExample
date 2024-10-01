using FluentResults;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface IGetUserByIdService
{
    Result<User> GetUserById(long id);
}