using FluentResults;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface IGetAllUsersService
{
    Result<List<User>> GetAllUsers();
}