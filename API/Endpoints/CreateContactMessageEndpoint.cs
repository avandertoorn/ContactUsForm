using API.Contracts.Requests;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace API.Endpoints;

[HttpPost("contactmessages"), AllowAnonymous]
public class CreateContactMessageEndpoint : Endpoint<CreateContactMessageRequest>
{
    public override Task HandleAsync(CreateContactMessageRequest req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}