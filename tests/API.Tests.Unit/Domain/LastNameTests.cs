using API.Domain.Common;
using FluentAssertions;
using FluentValidation;

namespace API.Tests.Unit.Domain;

public class LastNameTests
{
    [Fact]
    public void LastNameFrom_ShouldSucceed_WhenValid()
    {
        var lastName = "Smith";

        var lastNameType = LastName.From(lastName);

        lastNameType.Should().NotBeNull();
        lastNameType.Value.Should().Be(lastName);
    }
    
    [Fact]
    public async Task LastNameFrom_ShouldThrowValidationException_WhenTooShort()
    {
        var message = "";

        Action result = () => LastName.From(message);

        result.Should().Throw<ValidationException>();
    }
    
    [Fact]
    public async Task LastNameFrom_ShouldThrowValidationException_WhenTooLong()
    {
        var message = "";
        for(var i = 0; i < 51; i++)
        {
            message += "a";   
        }

        Action result = () => LastName.From(message);

        result.Should().Throw<ValidationException>();
    }
    
    [Fact]
    public async Task LastNameFrom_ShouldThrowValidationException_WhenNull()
    {
        string message = null!;

        Action result = () => LastName.From(message!);
        
        result.Should().Throw<ValidationException>();
    }
}