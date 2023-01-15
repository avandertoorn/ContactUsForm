namespace API.Contracts.Requests;

public sealed class CreateContactMessageRequest
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Message { get; init; }
}