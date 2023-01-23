using API.Domain;
using Shared.Contracts.Responses;

namespace API.Mapping;

public static class DomainToApiContractMapper
{
    public static ContactMessageResponse ToContactMessageResponse(this ContactMessage contactMessage)
    {
        return new ContactMessageResponse
        {
            Id = contactMessage.Id.Value,
            FirstName = contactMessage.FirstName.Value,
            LastName = contactMessage.LastName.Value,
            Email = contactMessage.Email.Value,
            Message = contactMessage.Message.Value,
            CreatedAt = contactMessage.CreatedAt
        };
    }
    
    public static GetAllContactMessageResponse ToContactMessagesResponse(this IEnumerable<ContactMessage> contactMessages)
    {
        return new GetAllContactMessageResponse
        {
            ContactMessages = contactMessages.Select(x => x.ToContactMessageResponse())
        };
    }
}