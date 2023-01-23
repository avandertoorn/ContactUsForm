using API.Domain;
using API.Mapping;
using API.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace API.Services;

public sealed class ContactMessageService : IContactMessageService
{
    private readonly IContactMessageRepository _repository;

    public ContactMessageService(IContactMessageRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> CreateAsync(ContactMessage contactMessageMessage)
    {
        var existing = await _repository.GetAsync(contactMessageMessage.Id.Value);
        
        if (existing is not null)
        {
            var message = $"Contact message with id {contactMessageMessage.Id} already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(ContactMessage), message)
            });
        }
        
        var result = await _repository.CreateAsync(contactMessageMessage.ToContactMessageDto());
        if(!result)
        {
            var message = $"Failed to create contact message with id {contactMessageMessage.Id}";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(ContactMessage), message)
            });
        }
        
        return result;
    }

    public async Task<ContactMessage?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id).ContinueWith(task => task.Result?.ToContactMessage());
    }

    public async Task<IEnumerable<ContactMessage>> GetAllAsync()
    {
        return await _repository.GetAllAsync().ContinueWith(task => task.Result.Select(x => x.ToContactMessage()));
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}