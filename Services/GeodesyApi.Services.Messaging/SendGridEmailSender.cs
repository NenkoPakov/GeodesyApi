namespace GeodesyApi.Services.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GeodesyApi.Common;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class SendGridEmailSender : IEmailSender
    {
        private readonly SendGridClient client;

        public SendGridEmailSender()
        { 
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID");

            this.client = new SendGridClient(apiKey);
        }

        /*
        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID");
            var client2 = new SendGridClient(apiKey);
            var from = new EmailAddress("nenko_pakov@abv.bg", "Nenko");
            var to = new EmailAddress("nenko.pakov@gmail.com", "Nenko");
            var subject = "asdasdsdsjdah asdjh askd ashkjd haskjfgdsyfau asd";
            var plainTextContent = "11111111111111asdasdsdsjdah asdjh askd ashkjd haskjfgdsyfau asd";
            var htmlContent = "<strong>AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var responce = await client2.SendEmailAsync(msg);
            ;
        }
        
        */

        public async Task SendEmailAsync(
            string to,
            string subject,
            string htmlContent,
            string from = GlobalConstants.SystemEmail,
            string fromName = GlobalConstants.SystemName,
            IEnumerable<EmailAttachment> attachments = null)
        {

            if (string.IsNullOrWhiteSpace(subject) && string.IsNullOrWhiteSpace(htmlContent))
            {
                throw new ArgumentException("Subject and message should be provided.");
            }

            var fromAddress = new EmailAddress(from, fromName);
            var toAddress = new EmailAddress(to);
            var message = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, null, htmlContent);
            if (attachments?.Any() == true)
            {
                foreach (var attachment in attachments)
                {
                    message.AddAttachment(attachment.FileName, Convert.ToBase64String(attachment.Content), attachment.MimeType);
                }
            }

            try
            {
                var response = await this.client.SendEmailAsync(message);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(await response.Body.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
