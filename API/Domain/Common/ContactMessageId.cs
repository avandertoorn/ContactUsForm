using ValueOf;

namespace API.Domain.Common;

public sealed class ContactMessageId : ValueOf<Guid, ContactMessageId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("ContactMessageId cannot be empty", nameof(ContactMessageId));
        }
    }
}