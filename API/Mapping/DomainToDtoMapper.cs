using API.Contracts.Data;
using API.Domain;

namespace API.Mapping;

public static class DomainToDtoMapper
{
    public static ContactMessageDto ToContactMessageDto(this ContactMessage contactMessage)
    {
        return new ContactMessageDto
        {
            Id = contactMessage.Id.Value,
            FirstName = contactMessage.FirstName.Value,
            LastName = contactMessage.LastName.Value,
            Email = contactMessage.Email.Value,
            Message = contactMessage.Message.Value,
            CreatedAt = contactMessage.CreatedAt
        };
    }
}