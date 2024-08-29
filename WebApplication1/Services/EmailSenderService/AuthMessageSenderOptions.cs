using System;

namespace WebApplication1.Services.EmailSenderService;

public class AuthMessageSenderOptions
{
    public string? PostmarkApiKey { get; set; }
    public string? FromEmail { get; set; }
}
