using API.Domain;
using API.Domain.Common;
using Shared.Contracts.Requests;

namespace API.Mapping;

public static class ApiContractToDomainMapper
{
    public static ContactMessage ToContactMessage(this CreateContactMessageRequest request)
    {
        return new ContactMessage
        {
            Id = ContactMessageId.From(Guid.NewGuid()),
            FirstName = FirstName.From(request.FirstName),
            LastName = LastName.From(request.LastName),
            Email = Email.From(request.Email),
            Message = Message.From(request.Message),
            CreatedAt = DateTime.Now
        };
    }
}