using API.Domain.Common;
using FluentAssertions;
using FluentValidation;

namespace API.Tests.Unit.Domain;

public class EmailTests
{
    [Fact]
    public async Task EmailFrom_ShouldSucceed_WhenEmailIsValid()
    {
        var email = "johndoe@email.com";

        var emailType = Email.From(email);

        emailType.Should().NotBeNull();
        emailType.Value.Should().Be(email);
    }

    [Fact]
    public async Task EmailFrom_ShouldThrowValidationException_WhenEmailIsInvalid()
    {
        var email = "invalidEmail.com";

        Action result = () => Email.From(email);
        
        result.Should().Throw<ValidationException>();
    }
}