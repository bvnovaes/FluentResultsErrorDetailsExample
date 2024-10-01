using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorDetailsExample.Infrastructure.Repositories;
using FluentResults;

namespace ErrorDetailsExample.Application.Users.Services;

public class CreateUserService(IUserRepository userRepository) : ICreateUserService
{
    public Result<User> CreateUser(User user)
    {
        return userRepository.AddUser(user);
    }
}