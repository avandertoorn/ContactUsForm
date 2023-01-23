using System.Text.Json;
using Shared.Contracts.Data;

namespace API.Repositories;

public sealed class ContactMessageRepository : IContactMessageRepository
{
    private readonly string _filePath = Path.Combine(Environment.CurrentDirectory, "ContactMessages.json");

    public ContactMessageRepository()
    {
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath).Close();
        }
    }

    public async Task<bool> CreateAsync(ContactMessageDto contactMessage)
    {
        var jsonObjects = await GetContactMessagesFromFileAsync();
        jsonObjects.Add(contactMessage);
        return await WriteContactMessagesToFileAsync(jsonObjects);
    }

    public async Task<ContactMessageDto?> GetAsync(Guid id)
    {
        var messages = await GetContactMessagesFromFileAsync();
        return messages.FirstOrDefault(x => x.Id == id);
    }
    
    public async Task<IEnumerable<ContactMessageDto>> GetAllAsync()
    {
        return await GetContactMessagesFromFileAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var messages = await GetContactMessagesFromFileAsync();
        var message = messages.FirstOrDefault(x => x.Id == id);
        if (message is null)
        {
            return false;
        }
        
        messages.Remove(message);
        return await WriteContactMessagesToFileAsync(messages);
    }

    private async Task<List<ContactMessageDto>> GetContactMessagesFromFileAsync()
    {
        try
        {
            var jsonString = await File.ReadAllTextAsync(_filePath);
            var jsonObjects = JsonSerializer.Deserialize<List<ContactMessageDto>>(jsonString) ?? new List<ContactMessageDto>();
            return jsonObjects;
        }
        catch(Exception)
        {
            return new List<ContactMessageDto>();
        }
    }
    
    private async Task<bool> WriteContactMessagesToFileAsync(List<ContactMessageDto> contactMessages)
    {
        try
        {
            var newJsonString = JsonSerializer.Serialize(contactMessages);
            await File.WriteAllTextAsync(_filePath, newJsonString);
            return true;
        }
        catch(Exception)
        {
            return false;
        }
    }
}