using API.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Shared.Contracts.Requests;

namespace API.Endpoints;

[HttpDelete("contactmessages/{id:guid}"), AllowAnonymous]
public class DeleteContactMessageEndpoint : Endpoint<DeleteContactMessageRequest>
{
    private readonly IContactMessageService _contactMessageService;

    public DeleteContactMessageEndpoint(IContactMessageService contactMessageService)
    {
        _contactMessageService = contactMessageService;
    }

    public override async Task HandleAsync(DeleteContactMessageRequest req, CancellationToken ct)
    {
        var deleted = await _contactMessageService.DeleteAsync(req.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        await SendNoContentAsync(ct);
    }
}