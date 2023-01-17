using System.Net;
using API.Contracts.Responses;
using FluentValidation;

namespace API.Validation;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _request;

    public ValidationExceptionMiddleware(RequestDelegate request)
    {
        _request = request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var message = ex.Errors.Select(x => x.ErrorMessage).ToList();
            var validationError = new ValidationFailureResponse()
            {
                Errors = message
            };
            await context.Response.WriteAsJsonAsync(validationError);
        }
    }
}