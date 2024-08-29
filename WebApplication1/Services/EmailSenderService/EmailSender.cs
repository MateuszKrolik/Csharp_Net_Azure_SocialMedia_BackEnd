using System;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using PostmarkDotNet;

namespace WebApplication1.Services.EmailSenderService;

public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;
    private readonly AuthMessageSenderOptions _options;

    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                       ILogger<EmailSender> logger)
    {
        _options = optionsAccessor.Value;
        _logger = logger;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(_options.PostmarkApiKey))
        {
            throw new Exception("Null PostmarkApiKey");
        }
        if (string.IsNullOrEmpty(_options.FromEmail))
        {
            throw new Exception("Null FromEmail");
        }
        await Execute(_options.PostmarkApiKey, _options.FromEmail, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string fromEmail, string subject, string message, string toEmail)
    {
        var client = new PostmarkClient(apiKey);
        var emailMessage = new PostmarkMessage
        {
            From = fromEmail,
            To = toEmail,
            Subject = subject,
            HtmlBody = message,
            TextBody = message
        };

        var response = await client.SendMessageAsync(emailMessage);
        _logger.LogInformation(response.Status == PostmarkStatus.Success
                               ? $"Email to {toEmail} queued successfully!"
                               : $"Failure Email to {toEmail}: {response.Message}");
    }
}

