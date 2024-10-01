using ErrorDetailsExample.Domain.Users;
using FluentResults;

namespace ErrorDetailsExample.Infrastructure.Repositories;

public interface IUserRepository
{
    Result<User> GetUserById(long id);
    Result<List<User>> GetAllUsers();
    Result<User> AddUser(User user);
    Result<User> UpdateUser(User user);
    Result<User> DeleteUser(long id);
}