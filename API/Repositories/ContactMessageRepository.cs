using System.Text.Json;
using API.Domain;

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

    public async Task<bool> CreateAsync(ContactMessage contactMessage)
    {
        var jsonObjects = await GetContactMessagesFromFileAsync();
        jsonObjects.Add(contactMessage);
        return await WriteContactMessagesToFileAsync(jsonObjects);
    }

    public async Task<ContactMessage?> GetAsync(Guid id)
    {
        var messages = await GetContactMessagesFromFileAsync();
        return messages.FirstOrDefault(x => x.Id.Value == id);
    }
    
    private async Task<List<ContactMessage>> GetContactMessagesFromFileAsync()
    {
        try
        {
            var jsonString = await File.ReadAllTextAsync(_filePath);
            var jsonObjects = JsonSerializer.Deserialize<List<ContactMessage>>(jsonString) ?? new List<ContactMessage>();
            return jsonObjects;
        }
        catch(Exception e)
        {
            return new List<ContactMessage>();
        }
    }
    
    private async Task<bool> WriteContactMessagesToFileAsync(List<ContactMessage> contactMessages)
    {
        try
        {
            var newJsonString = JsonSerializer.Serialize(contactMessages);
            await File.WriteAllTextAsync(_filePath, newJsonString);
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }
}