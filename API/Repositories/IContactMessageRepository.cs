using API.Domain;

namespace API.Repositories;

public interface IContactMessageRepository
{
    Task<bool> CreateAsync(ContactMessage contactMessage);
    Task<ContactMessage?> GetAsync(Guid id);
}