using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace API.Tests.Integration.Endpoints;

[Collection("Database tests")]
public class GetContactMessageEndpointTests : IClassFixture<ApiFactory>
{
    private readonly HttpClient _httpClient;
    
    public GetContactMessageEndpointTests(ApiFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Get_ShouldReturnOk_WhenContactMessageExists()
    {
        var response = await _httpClient.PostAsJsonAsync("contactmessages", new CreateContactMessageRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@email.com",
            Message = "Hello World at Delete, thanks for the great time!"
        });
        
        var getAllResponse = await _httpClient.GetAsync("contactmessages");
        var contactMessages = await getAllResponse.Content.ReadFromJsonAsync<GetAllContactMessageResponse>();
        var getResponse = await _httpClient.GetAsync($"contactmessages/{contactMessages!.ContactMessages.First().Id}");
        var contactMessage = await getResponse.Content.ReadFromJsonAsync<ContactMessageResponse>();

        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task Get_ShouldReturnNotFound_WhenContactMessageDoesNotExists()
    {
        var getResponse = await _httpClient.GetAsync($"contactmessages/{Guid.NewGuid()}");

        getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}