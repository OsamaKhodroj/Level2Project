using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure
{
    public class EmailManager
    {
        public async Task<bool> SendEmail(string sendTo, string emailSubject, string body)
        {
            if (string.IsNullOrEmpty(sendTo))
                throw new ArgumentException("Recipient email cannot be null or empty.", nameof(sendTo));
            if (string.IsNullOrEmpty(emailSubject))
                throw new ArgumentException("Email subject cannot be null or empty.", nameof(emailSubject));
            if (string.IsNullOrEmpty(body))
                throw new ArgumentException("Email body cannot be null or empty.", nameof(body));



            var apiKey = "";
            var client = new SendGridClient(apiKey);


            var from = new EmailAddress("test@example.com", "Example User"); 
            var to = new EmailAddress(sendTo, "Example User");
            var plainTextContent = body;
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, emailSubject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
