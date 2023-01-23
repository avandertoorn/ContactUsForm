using Shared.Contracts.Data;

namespace API.Repositories;

public interface IContactMessageRepository
{
    Task<bool> CreateAsync(ContactMessageDto contactMessage);
    Task<ContactMessageDto?> GetAsync(Guid id);
}