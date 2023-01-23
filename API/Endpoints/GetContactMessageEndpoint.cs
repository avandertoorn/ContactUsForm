using API.Mapping;
using API.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace API.Endpoints;

[HttpGet("contactmessages/{id:guid}"), AllowAnonymous]
public class GetContactMessageEndpoint : Endpoint<GetContactMessageRequest, ContactMessageResponse>
{
    private readonly IContactMessageService _contactMessageService;

    public GetContactMessageEndpoint(IContactMessageService contactMessageService)
    {
        _contactMessageService = contactMessageService;
    }

    public override async Task HandleAsync(GetContactMessageRequest req, CancellationToken ct)
    {
        var contactMessage = await _contactMessageService.GetAsync(req.Id);
        if (contactMessage is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var contactMessageResponse = contactMessage.ToContactMessageResponse();
        await SendOkAsync(contactMessageResponse, ct);
    }
}
