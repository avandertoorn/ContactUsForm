using API.Contracts.Responses;
using API.Repositories;
using API.Services;
using API.Validation;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddSingleton<IContactMessageRepository, ContactMessageRepository>();
builder.Services.AddSingleton<IContactMessageService, ContactMessageService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints(x =>
{
    x.Errors.ResponseBuilder = (list, _, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = list.Select(y => y.ErrorMessage).ToList()
        };
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();