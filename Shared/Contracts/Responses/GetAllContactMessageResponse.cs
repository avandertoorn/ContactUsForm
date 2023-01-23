namespace Shared.Contracts.Responses;

public sealed class GetAllContactMessageResponse
{
    public IEnumerable<ContactMessageResponse> ContactMessages { get; init; } =
        Enumerable.Empty<ContactMessageResponse>();
}