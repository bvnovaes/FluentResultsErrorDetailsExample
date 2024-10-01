using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorDetailsExample.Infrastructure.Repositories;
using FluentResults;

namespace ErrorDetailsExample.Application.Users.Services;

public class GetUserByIdService(IUserRepository userRepository) : IGetUserByIdService
{
    public Result<User> GetUserById(long id)
    {
        return userRepository.GetUserById(id);
    }
}