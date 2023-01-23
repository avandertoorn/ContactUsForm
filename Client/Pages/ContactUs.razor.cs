using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using Client.Services;
using Microsoft.AspNetCore.Components;
using Shared.Contracts.Data;
using Shared.Contracts.Requests;
using Client.Models;

namespace Client.Pages;

public partial class ContactUs
{
    [Inject]
    ContactMessageService ConversationMessageService { get; set; }

    public ContactMessage ContactMessage { get; set; } = new();
    public string Message { get; set; } = string.Empty;
    private async Task SubmitContactMessage()
    {
        var request = new CreateContactMessageRequest()
        {
            FirstName = ContactMessage.FirstName,
            LastName = ContactMessage.LastName,
            Email = ContactMessage.Email,
            Message = ContactMessage.Message
        };

        var responseMessage = await ConversationMessageService.CreateAsync(request);
        if (responseMessage.IsSuccessStatusCode)
        {
            Message = "Message was successfully sent";
            ContactMessage = new();
        }
        else
        {
            Message = "There was an error sending your message. Please try again later.";
        }
    }
}