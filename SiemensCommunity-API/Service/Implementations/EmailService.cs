using Microsoft.Extensions.Options;
using MimeKit;
using Service.Contracts;
using Service.Models;
using System;
using MailKit.Net.Smtp;

namespace Service.Implementations
{
    public class EmailService : IEmailService
    {
        EmailConfiguration _emailConfiguration = null;
        public EmailService(IOptions<EmailConfiguration> options)
        {
            _emailConfiguration = options.Value;
        }

        public bool SendEmail(EmailData emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailConfiguration.Name, _emailConfiguration.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(emailData.EmailToName, emailData.EmailToId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = emailData.EmailSubject;

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = emailData.EmailBody;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(_emailConfiguration.Host, _emailConfiguration.Port, _emailConfiguration.UseSSL);
                emailClient.Authenticate(_emailConfiguration.EmailId, _emailConfiguration.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }
    }
}
