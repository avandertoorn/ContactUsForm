using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace API.Tests.Integration.Endpoints;

[Collection("Database tests")]
public class GetAllContactMessageEndpointTests : IClassFixture<ApiFactory>
{
    private readonly HttpClient _httpClient;

    public GetAllContactMessageEndpointTests(ApiFactory appFactory)
    {
        _httpClient = appFactory.CreateClient();
    }
    
    [Fact]
    public async Task GetAll_ShouldReturnOk_WhenCalled()
    {
        var response = await _httpClient.PostAsJsonAsync("contactmessages", new CreateContactMessageRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@email.com",
            Message = "Hello World at Delete, thanks for the great time!"
        });
        
        var getAllResponse = await _httpClient.GetAsync("contactmessages");
        
        getAllResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}