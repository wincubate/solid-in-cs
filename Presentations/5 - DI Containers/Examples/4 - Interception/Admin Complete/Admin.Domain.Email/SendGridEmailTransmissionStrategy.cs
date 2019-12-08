using Admin.Domain.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Admin.Domain.Email
{
    public class SendGridEmailTransmissionStrategy : IMessageTransmissionStrategy
    {
        public async Task TransmitAsync(User recipient, InstantiatedMessage instance)
        {
            ISendGridClient client = new SendGridClient(SendGridConstants.ApiKey);

            EmailAddress from = new EmailAddress(
                SendGridConstants.FromEmail, 
                SendGridConstants.FromName
            );
            EmailAddress to = new EmailAddress(
                recipient.Email,
                recipient.Name
            );

            SendGridMessage emailMessage = MailHelper.CreateSingleEmail(
                from, 
                to, 
                instance.Subject, 
                instance.Body,
                null
            );

            await client.SendEmailAsync(emailMessage);
        }
    }
}
