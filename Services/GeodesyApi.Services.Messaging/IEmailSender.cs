namespace GeodesyApi.Services.Messaging
{
    using GeodesyApi.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task SendEmailAsync(
            string to,
            string subject,
            string htmlContent,
            string from = GlobalConstants.SystemEmail,
            string fromName = GlobalConstants.SystemName,
            IEnumerable<EmailAttachment> attachments = null);
    }
}
