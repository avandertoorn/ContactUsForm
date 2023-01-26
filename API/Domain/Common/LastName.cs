using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace API.Domain.Common;

public class LastName : ValueOf<string, LastName>
{
    private static readonly Regex NameRegex = 
        new Regex(@"^(?=.{1,50}$)[a-zA-Z ]+$", RegexOptions.Compiled);
    
    protected override void Validate()
    {
        var message = $"{Value} is not a valid last name";
        if (Value is null)
        {
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(LastName), message)
            });
        }
        if(!NameRegex.IsMatch(Value))
        {
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(LastName), message)
            });
        }
    }
}