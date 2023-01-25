using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace API.Tests.Integration.Endpoints;

[Collection("Database tests")]
public class DeleteContactMessageEndpointTests : IClassFixture<ApiFactory>
{
    private readonly HttpClient _httpClient;
    
    public DeleteContactMessageEndpointTests(ApiFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Delete_ShouldReturnNoContent_WhenContactMessageExists()
    {
        var response = await _httpClient.PostAsJsonAsync("contactmessages", new CreateContactMessageRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@email.com",
            Message = "Hello World at Delete, thanks for the great time!"
        });
        
        var getResponse = await _httpClient.GetAsync("contactmessages");
        var contactMessages = await getResponse.Content.ReadFromJsonAsync<GetAllContactMessageResponse>();
        var deleteResponse = await _httpClient.DeleteAsync($"contactmessages/{contactMessages!.ContactMessages.First().Id}");

        deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task Delete_ShouldReturnNotFound_WhenContactMessageDoesNotExists()
    {
        var deleteResponse = await _httpClient.DeleteAsync($"contactmessages/{Guid.NewGuid()}");

        deleteResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}