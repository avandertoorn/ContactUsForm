using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Shared.Contracts.Requests;

namespace API.Tests.Integration.Endpoints;

[Collection("Database tests")]
public class CreateContactMessageEndpointTests : IClassFixture<ApiFactory>
{
    private readonly HttpClient _httpClient;

    public CreateContactMessageEndpointTests(ApiFactory appFactory)
    {
        _httpClient = appFactory.CreateClient();
    }

    [Fact]
    public async Task Create_ReturnsOk_WhenValidRequest()
    {
        var response = await _httpClient.PostAsJsonAsync("contactmessages", new CreateContactMessageRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@email.com",
            Message = "Hello World, thanks for the great time!"
        });

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Create_ReturnsBadRequest_WhenInvalidRequest()
    {
        var response = await _httpClient.PostAsJsonAsync("contactmessages", new CreateContactMessageRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "",
            Message = "Hello World, thanks for the great time!"
        });

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}