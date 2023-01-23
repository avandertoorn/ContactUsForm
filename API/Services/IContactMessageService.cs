using API.Domain;

namespace API.Services;

public interface IContactMessageService
{
    Task<bool> CreateAsync(ContactMessage contactMessageMessage);
    Task<ContactMessage?> GetAsync(Guid id);
    Task<IEnumerable<ContactMessage>> GetAllAsync();

    Task<bool> DeleteAsync(Guid id);
}