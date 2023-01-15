using API.Domain;

namespace API.Services;

public interface IContactMessageService
{
    Task<bool> CreateAsync(ContactMessage contactMessageMessage);
}