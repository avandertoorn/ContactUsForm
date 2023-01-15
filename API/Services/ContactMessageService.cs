﻿using API.Domain;
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
        
        return await _repository.CreateAsync(contactMessageMessage);
    }
}