﻿using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Core.Persistance.MailServices;

public sealed class SmtpService
{
    private readonly SmtpSettings _settings;

    public SmtpService(IConfiguration configuration)
    {
        _settings = new SmtpSettings();
        configuration.GetSection("Smtp").Bind(_settings);
    }

    public void SendMessage(string to, string subject, string body)
    {
        if (string.IsNullOrEmpty(to)) throw new ArgumentException("Recipient email is not valid");
        if (string.IsNullOrEmpty(subject)) throw new ArgumentException("Email subject is not valid");
        if (string.IsNullOrEmpty(body)) throw new ArgumentException("Email body is not valid");

        using var smtpClient = new SmtpClient(_settings.SmtpAddress, _settings.PortNumber)
        {
            Credentials = new NetworkCredential(_settings.SenderEmail, _settings.Password),
            EnableSsl = true
        };

        using var message = new MailMessage(_settings.SenderEmail, to)
        {
            Body = body,
            Subject = subject,
            Priority = MailPriority.High,
            IsBodyHtml = true,
            DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
        };

        try
        {
            smtpClient.Send(message);
        }
        catch (SmtpException smtpEx)
        {
            Console.WriteLine($"SMTP Exception: {smtpEx.Message}");
            throw new InvalidOperationException("Failed to send email due to SMTP error.", smtpEx);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send: {ex.Message}");
            throw new InvalidOperationException("Failed to send email.", ex);
        }
    }

    public void SendMessage(string to, string subject, string body, byte[] attachment, string attachmentFileName)
    {
        if (string.IsNullOrEmpty(to)) throw new ArgumentException("Recipient email is not valid");
        if (string.IsNullOrEmpty(subject)) throw new ArgumentException("Email subject is not valid");
        if (string.IsNullOrEmpty(body)) throw new ArgumentException("Email body is not valid");
        if (attachment == null || attachment.Length == 0) throw new ArgumentException("Attachment is empty.");

        using var smtpClient = new SmtpClient(_settings.SmtpAddress, _settings.PortNumber)
        {
            Credentials = new NetworkCredential(_settings.SenderEmail, _settings.Password),
            EnableSsl = true
        };

        using var message = new MailMessage(_settings.SenderEmail, to)
        {
            Body = body,
            Subject = subject,
            Priority = MailPriority.High,
            IsBodyHtml = true,
            DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
        };

        using var attachmentStream = new MemoryStream(attachment);
        var mailAttachment = new Attachment(attachmentStream, attachmentFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        message.Attachments.Add(mailAttachment);

        try
        {
            smtpClient.Send(message);
        }
        catch (SmtpException smtpEx)
        {
            Console.WriteLine($"SMTP Exception: {smtpEx.Message}");
            throw new InvalidOperationException("Failed to send email due to SMTP error.", smtpEx);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send: {ex.Message}");
            throw new InvalidOperationException("Failed to send email.", ex);
        }
    }

}
