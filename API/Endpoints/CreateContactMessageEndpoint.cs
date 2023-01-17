using API.Contracts.Requests;
using API.Mapping;
using API.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace API.Endpoints;

[HttpPost("contactmessages"), AllowAnonymous]
public class CreateContactMessageEndpoint : Endpoint<CreateContactMessageRequest>
{
    private readonly IContactMessageService _contactMessageService;

    public CreateContactMessageEndpoint(IContactMessageService contactMessageService)
    {
        _contactMessageService = contactMessageService;
    }
    
    public override async Task HandleAsync(CreateContactMessageRequest req, CancellationToken ct)
    {
        var contactMessage = req.ToContactMessage();
        await _contactMessageService.CreateAsync(contactMessage);
        await SendOkAsync(ct);
    }
}