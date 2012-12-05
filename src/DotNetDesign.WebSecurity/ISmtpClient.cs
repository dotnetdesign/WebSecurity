using System.Net.Mail;

namespace DotNetDesign.WebSecurity
{
    public interface ISmtpClient
    {
        /// <summary>
        /// Sends the specified mail message.
        /// </summary>
        /// <param name="mailMessage">The mail message.</param>
        void Send(MailMessage mailMessage);
    }
}