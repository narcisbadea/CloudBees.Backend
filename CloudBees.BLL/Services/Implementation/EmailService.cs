using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using CloudBees.BLL.Services.Interfaces;
using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;

namespace CloudBees.BLL.Services.Implementation;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtp;
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
        _smtp = new SmtpClient();
        _smtp.Connect(configuration["Email:Host"], int.Parse(configuration["Email:Port"]), SecureSocketOptions.StartTls);
        _smtp.Authenticate(configuration["Email:Login"], configuration["Email:Password"]);
    }
    public void Send(EmailRequestDTO emailRequest)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_configuration["Email:Login"]));
        email.To.Add(MailboxAddress.Parse(_configuration["Email:AdminEmail"]));
        email.To.Add(MailboxAddress.Parse(_configuration["Email:AdminEmail2"]));
        email.Subject = "CloudBees contact";
        var body = $"Utilizatorul cu numele {emailRequest.FirstName} {emailRequest.LastName} si adresa de e-mail {emailRequest.Email}" +
            $" v-a trimis urmatorul mesaj:\n \"{emailRequest.Details}\"";
        email.Body = new TextPart(TextFormat.Plain) { Text = body };

        _smtp.Send(email);
        _smtp.Disconnect(true);
    }
}
