using API.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace API.Tests.Integration;

public class ApiFactory : WebApplicationFactory<IApiMarker>, IAsyncLifetime
{
    private readonly string _filePath = Path.Combine(Environment.CurrentDirectory, "TestContactMessages.json");
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IDbConnectionProvider));
            services.AddSingleton<IDbConnectionProvider>(_ =>
                new DbConnectionProvider(_filePath));
        });
    }

    public async Task InitializeAsync()
    {
        if (!File.Exists(_filePath))
            File.Create(_filePath).Close();
    }

    public new async Task DisposeAsync()
    {
        if (File.Exists(_filePath))
            File.Delete(_filePath);
    }
}