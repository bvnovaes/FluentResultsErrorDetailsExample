using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ErrorDetailsExample.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected ActionResult Problem(List<IError> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }

        return errors.All(error => error.Metadata.ContainsKey("Validation"))
            ? ValidationProblem(errors)
            : Problem(errors[0]);
    }

    private ObjectResult Problem(IError error)
    {
        var statusCode =
            error.Metadata.ContainsKey("Conflict") ? StatusCodes.Status409Conflict :
            error.Metadata.ContainsKey("Validation") ? StatusCodes.Status400BadRequest :
            error.Metadata.ContainsKey("NotFound") ? StatusCodes.Status404NotFound :
            error.Metadata.ContainsKey("Unauthorized") ? StatusCodes.Status401Unauthorized :
            error.Metadata.ContainsKey("Forbidden") ? StatusCodes.Status403Forbidden :
            StatusCodes.Status500InternalServerError;
    
        return Problem(statusCode: statusCode, title: error.Message);
    }

    private ActionResult ValidationProblem(List<IError> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        errors.ForEach(error => modelStateDictionary.AddModelError(error.Metadata["PropertyName"].ToString(), error.Message));

        return ValidationProblem(modelStateDictionary);
    }
}