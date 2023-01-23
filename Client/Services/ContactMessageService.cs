using Shared.Contracts.Requests;
using System.Net.Http.Json;

namespace Client.Services
{
    public class ContactMessageService
    {
        private readonly HttpClient _httpClient;

        public ContactMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateAsync(CreateContactMessageRequest request)
        {
            return await _httpClient.PostAsJsonAsync("contactmessages", request);
        }
    }
}
