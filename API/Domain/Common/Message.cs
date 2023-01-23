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
        if (Value.Length > 500)
        {
            var message = "Message cannot be longer than 500 characters";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Message), message)
            });
        }
        if(Value.Length < 20)
        {
            var message = "Message must be at least 20 characters";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Message), message)
            });
        }
    }
}