using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace API.Domain.Common;

public sealed class FirstName : ValueOf<string, FirstName>
{
    private static readonly Regex NameRegex = 
        new Regex(@"^(?=.{1,40}$)[a-zA-Z ]+$", RegexOptions.Compiled);
    
    protected override void Validate()
    {
        if(!NameRegex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid first name";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(FirstName), message)
            });
        }
    }
}