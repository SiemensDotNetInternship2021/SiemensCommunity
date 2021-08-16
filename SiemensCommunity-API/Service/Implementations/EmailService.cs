using Microsoft.Extensions.Options;
using MimeKit;
using Service.Contracts;
using Service.Models;
using System;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Common;

namespace Service.Implementations
{
    public class EmailService : IEmailService
    {
        EmailConfiguration _emailConfiguration = null;
        private readonly ILogger _logger;
        private readonly ILogService _logService;

        public EmailService(IOptions<EmailConfiguration> options,ILogService logService, ILoggerFactory logger)
        {
            _emailConfiguration = options.Value;
            _logger = logger.CreateLogger("Email service");
            _logService = logService;
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

                _logger.LogInformation(MyLogEvents.EmailSent, "Email sent.");
                _logService.SaveAsync(LogLevel.Information, MyLogEvents.EmailSent, "Email has been sent.", Environment.StackTrace);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.ErrorEmailSent, "Error sending email" + ex.Message);
                _logService.SaveAsync(LogLevel.Error, MyLogEvents.EmailSent, ex.Message, ex.StackTrace);
                return false;
            }
        }
    }
}
