using AutoMapper;
using ErrorDetailsExample.Contracts.Requests;
using ErrorDetailsExample.Contracts.Responses;
using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ErrorDetailsExample.Api.Controllers;

[Route("[controller]")]
public class UsersController(
    IGetAllUsersService getAllUsersService,
    IGetUserByIdService getUserByIdService,
    ICreateUserService createUserService,
    IUpdateUserService updateUserService,
    IDeleteUserService deleteUserService,
    IMapper mapper,
    IValidator<CreateUserRequest> validator) : ApiController
{
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        Result<List<User>> result = getAllUsersService.GetAllUsers();

        return !result.IsSuccess
            ? Problem(result.Errors)
            : Ok(result.Value);
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        ValidationResult? validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            List<IError> errors = validationResult.Errors
                .Select(e => new Error(e.ErrorMessage)
                    .WithMetadata("Validation", true)
                    .WithMetadata("PropertyName", e.PropertyName))
                .Cast<IError>()
                .ToList();

            return Problem(errors);
        }
        
        var user = mapper.Map<User>(request);
        Result<User> result = createUserService.CreateUser(user);

        return !result.IsSuccess
            ? Problem(result.Errors)
            : CreatedAtAction(nameof(CreateUser), new { id = result.Value.Id }, mapper.Map<UserResponse>(result.Value));
    }

    [HttpGet("{id:long}")]
    public IActionResult GetUserById(long id)
    {
        Result<User> result = getUserByIdService.GetUserById(id);

        return !result.IsSuccess
            ? Problem(result.Errors)
            : Ok(mapper.Map<UserResponse>(result.Value));
    }

    [HttpPut("{id:long}")]
    public ActionResult<UserResponse> UpdateUser(long id, UpdateUserRequest request)
    {
        User user = mapper.Map<User>(request) with { Id = id };
        Result<User> result = updateUserService.UpdateUser(user);

        return !result.IsSuccess
            ? Problem(result.Errors)
            : Ok(result.Value);
    }

    [HttpDelete("{id:long}")]
    public ActionResult DeleteUser(long id)
    {
        Result<User> result = deleteUserService.DeleteUser(id);

        return !result.IsSuccess
            ? Problem(result.Errors)
            : NoContent();
    }
}