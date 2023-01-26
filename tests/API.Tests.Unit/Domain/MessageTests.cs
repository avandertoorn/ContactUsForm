using System.Runtime.CompilerServices;
using API.Domain.Common;
using FluentAssertions;
using FluentValidation;

namespace API.Tests.Unit.Domain;

public class MessageTests
{
    [Fact]
    public async Task MessageFrom_ShouldSucceed_WhenValid()
    {
        string message = "This is a valid message";

        var messageType = Message.From(message);
        
        messageType.Should().NotBeNull();
        messageType.Value.Should().Be(message);
    }
    
    [Fact]
    public async Task MessageFrom_ShouldThrowValidationException_WhenTooShort()
    {
        var message = "too short";

        Action result = () => Message.From(message);
        
        result.Should().Throw<ValidationException>()
            .WithMessage("Message must be at least 20 characters");
    }
    
    [Fact]
    public async Task MessageFrom_ShouldThrowValidationException_WhenTooLong()
    {
        var message = "";
        for(var i = 0; i < 501; i++)
        {
            message += "a";   
        }

        Action result = () => Message.From(message);
        
        result.Should().Throw<ValidationException>()
            .WithMessage("Message cannot be longer than 500 characters");
    }
    
    [Fact]
    public async Task MessageFrom_ShouldThrowValidationException_WhenNull()
    {
        string message = null!;

        Action result = () => Message.From(message!);
        
        result.Should().Throw<ValidationException>()
            .WithMessage("Message cannot be null");
    }
}