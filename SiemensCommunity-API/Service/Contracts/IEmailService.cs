using Service.Models;

namespace Service.Contracts
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }
}
