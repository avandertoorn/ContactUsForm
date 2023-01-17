using API.Contracts.Requests;
using FluentValidation;

namespace API.Validation;

public class CreateContactMessageValidator : AbstractValidator<CreateContactMessageRequest>
{
    public CreateContactMessageValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Message).NotEmpty();
    }
}