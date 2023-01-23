namespace Shared.Contracts.Responses;

public sealed class ContactMessageResponse
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Message { get; init; }
    public DateTime CreatedAt { get; init; }
}