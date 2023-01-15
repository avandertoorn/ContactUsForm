using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace API.Domain.Common;

public sealed class Email : ValueOf<string, Email>
{
    private static readonly Regex EmailRegex =
        new(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$",
            RegexOptions.Compiled);
    
    protected override void Validate()
    {
        if (!EmailRegex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid email address";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Email), message)
            });
        }
    }
}