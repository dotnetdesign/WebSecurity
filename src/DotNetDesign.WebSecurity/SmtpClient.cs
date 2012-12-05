using System.Linq;
using System.Net.Mail;
using DotNetDesign.Common;

namespace DotNetDesign.WebSecurity
{
    public class SmtpClient : ISmtpClient
    {
        private readonly System.Net.Mail.SmtpClient _smtpClient;

        public SmtpClient()
            : this(new System.Net.Mail.SmtpClient())
        {

        }
        
        public SmtpClient(System.Net.Mail.SmtpClient smtpClient)
        {
            using (Logger.Assembly.Scope())
            {
                _smtpClient = smtpClient;
            }
        }

        public void Send(MailMessage mailMessage)
        {
            using (Logger.Assembly.Scope())
            {
                Logger.Assembly.Debug(m => m("Sending mail message. From: {0}, To: {1}, CC: {2}, BCC: {3}, Subject: {4}, Body: {5}, Attachments: {6}", 
                    mailMessage.From, 
                    string.Join(";", mailMessage.To),
                    string.Join(";", mailMessage.CC),
                    string.Join(";", mailMessage.Bcc),
                    mailMessage.Subject,
                    mailMessage.Body,
                    mailMessage.Attachments.Count));

                _smtpClient.Send(mailMessage);
            }
        }
    }
}