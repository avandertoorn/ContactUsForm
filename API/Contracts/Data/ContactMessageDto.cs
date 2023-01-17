namespace API.Contracts.Data;

public class ContactMessageDto
{
    public Guid Id { get; init; } = default!;
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Message { get; init; } = default!;
    public DateTime CreatedAt { get; init; }
    
}