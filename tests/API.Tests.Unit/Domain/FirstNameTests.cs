using API.Domain.Common;
using FluentAssertions;
using FluentValidation;

namespace API.Tests.Unit.Domain;

public class FirstNameTests
{
    [Fact]
    public async Task FirstNameFrom_ShouldSucceed_WhenValid()
    {
        var firstName = "Jogn";
        
        var firstNameType = FirstName.From(firstName);
        
        firstNameType.Should().NotBeNull();
        firstNameType.Value.Should().Be(firstName);
    }
    
    [Fact]
    public async Task FirstNameFrom_ShouldThrowValidationException_WhenTooShort()
    {
        var message = "";

        Action result = () => FirstName.From(message);

        result.Should().Throw<ValidationException>();
    }
    
    [Fact]
    public async Task FirstNameFrom_ShouldThrowValidationException_WhenTooLong()
    {
        var message = "";
        for(var i = 0; i < 51; i++)
        {
            message += "a";   
        }

        Action result = () => FirstName.From(message);

        result.Should().Throw<ValidationException>();
    }
    
    [Fact]
    public async Task FirstFrom_ShouldThrowValidationException_WhenNull()
    {
        string message = null!;

        Action result = () => FirstName.From(message!);
        
        result.Should().Throw<ValidationException>();
    }
}