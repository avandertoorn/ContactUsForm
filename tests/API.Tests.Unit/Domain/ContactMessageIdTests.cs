using API.Domain.Common;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;

namespace API.Tests.Unit.Domain;

public class ContactMessageIdTests
{
    [Fact]
    public async Task From_ShouldSucceed_WhenValid()
    {
        var contactMessageId = Guid.NewGuid();
        
        var contactMessageResult = ContactMessageId.From(contactMessageId);

        contactMessageResult.Should().NotBeNull();
        contactMessageResult.Value.Should().Be(contactMessageId);
    }
    
    [Fact]
    public async Task From_ShouldThrowValidationException_WhenEmpty()
    {
        var contactMessageId = Guid.Empty;
        
        Action result = () => ContactMessageId.From(contactMessageId);

        result.Should().Throw<ArgumentException>();
    }
}