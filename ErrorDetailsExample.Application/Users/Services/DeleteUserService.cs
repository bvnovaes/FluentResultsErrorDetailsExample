using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorDetailsExample.Infrastructure.Repositories;
using FluentResults;

namespace ErrorDetailsExample.Application.Users.Services;

public class DeleteUserService(IUserRepository userRepository) : IDeleteUserService
{
    public Result<User> DeleteUser(long id)
    {
        return userRepository.DeleteUser(id);
    }
}