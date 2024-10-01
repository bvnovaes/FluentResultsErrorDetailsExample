using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorDetailsExample.Infrastructure.Repositories;
using FluentResults;

namespace ErrorDetailsExample.Application.Users.Services;

public class GetAllAllUsersService(IUserRepository userRepository) : IGetAllUsersService
{
    public Result<List<User>> GetAllUsers()
    {
        return userRepository.GetAllUsers();
    }
}