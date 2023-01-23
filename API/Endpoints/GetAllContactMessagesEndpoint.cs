using API.Mapping;
using API.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Shared.Contracts.Responses;

namespace API.Endpoints;

[HttpGet("contactmessages"), AllowAnonymous]
public class GetAllContactMessagesEndpoint : EndpointWithoutRequest<GetAllContactMessageResponse>
{
    private readonly IContactMessageService _contactMessageService;

    public GetAllContactMessagesEndpoint(IContactMessageService contactMessageService)
    {
        _contactMessageService = contactMessageService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var contactMessages = await _contactMessageService.GetAllAsync();

        var contactMessageResponse = contactMessages.ToContactMessagesResponse();
        await SendOkAsync(contactMessageResponse, ct);

    }
}