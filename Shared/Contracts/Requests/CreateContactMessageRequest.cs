namespace Shared.Contracts.Requests;

public sealed class CreateContactMessageRequest
{
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Message { get; init; } = default!;
}