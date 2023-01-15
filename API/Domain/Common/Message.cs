using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace API.Domain.Common;

public class Message : ValueOf<string, Message>
{
    protected override void Validate()
    {
        if (Value is null)
        {
            var message = "Message cannot be null";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Message), message)
            });
        }
        if (Value.Length > 1000)
        {
            var message = "Message cannot be longer than 1000 characters";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Message), message)
            });
        }
        if(Value.Length < 1)
        {
            var message = "Message cannot be empty";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Message), message)
            });
        }
    }
}