using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace API.Domain.Common;

public sealed class FirstName : ValueOf<string, FirstName>
{
    private static readonly Regex NameRegex = 
        new Regex(@"^(?=.{1,50}$)[a-zA-Z ]+$", RegexOptions.Compiled);
    
    protected override void Validate()
    {
        var message = $"{Value} is not a valid first name";
        if (Value is null)
        {
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(FirstName), message)
            });
        }
        if(!NameRegex.IsMatch(Value))
        {
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(FirstName), message)
            });
        }
    }
}