using Shared.Contracts.Data;

namespace API.Repositories;

public interface IContactMessageRepository
{
    Task<bool> CreateAsync(ContactMessageDto contactMessage);
    Task<ContactMessageDto?> GetAsync(Guid id);
    Task<IEnumerable<ContactMessageDto>> GetAllAsync();
    Task<bool> DeleteAsync(Guid id);
}