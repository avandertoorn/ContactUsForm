using API.Database;
using API.Repositories;
using API.Services;
using API.Validation;
using FastEndpoints;
using FastEndpoints.Swagger;
using Shared.Contracts.Responses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddSingleton<IContactMessageRepository, ContactMessageRepository>();
builder.Services.AddSingleton<IContactMessageService, ContactMessageService>();
builder.Services.AddSingleton<IDbConnectionProvider, DbConnectionProvider>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();

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

app.MapFallbackToFile("index.html");

app.Run();