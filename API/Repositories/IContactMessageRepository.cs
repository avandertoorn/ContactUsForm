using API.Contracts.Data;
using API.Domain;

namespace API.Repositories;

public interface IContactMessageRepository
{
    Task<bool> CreateAsync(ContactMessageDto contactMessage);
    Task<ContactMessageDto?> GetAsync(Guid id);
}