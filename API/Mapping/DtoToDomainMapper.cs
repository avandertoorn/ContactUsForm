using API.Domain;
using API.Domain.Common;
using Shared.Contracts.Data;

namespace API.Mapping;

public static class DtoToDomainMapper
{
    public static ContactMessage ToContactMessage(this ContactMessageDto contactMessageDto)
    {
        return new ContactMessage
        {
            Id = ContactMessageId.From(contactMessageDto.Id),
            FirstName = FirstName.From(contactMessageDto.FirstName),
            LastName = LastName.From(contactMessageDto.LastName),
            Email = Email.From(contactMessageDto.Email),
            Message = Message.From(contactMessageDto.Message),
            CreatedAt = contactMessageDto.CreatedAt
        };
    }
}