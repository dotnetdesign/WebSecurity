using System.Linq;
using System.Net.Mail;
using DotNetDesign.Common;

namespace DotNetDesign.WebSecurity
{
    public class SmtpEmailService : IEmailService
    {
        private readonly ISmtpClient _smtpClient;

        public SmtpEmailService()
            : this(new SmtpClient())
        {

        }

        public SmtpEmailService(ISmtpClient smtpClient)
        {
            using (Logger.Assembly.Scope())
            {
                _smtpClient = smtpClient;
            }
        }

        public void Send(string toAddress, string subject, string body, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(string.Empty, new []{toAddress}, new string[0], new string[0], subject, body, new Attachment[0], isBodyHtml);
            }
        }

        public void Send(string toAddress, string subject, string body, Attachment[] attachments, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(string.Empty, new []{toAddress}, new string[0], new string[0], subject, body, attachments, isBodyHtml);
            }
        }

        public void Send(string[] toAddresses, string subject, string body, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(string.Empty, toAddresses, new string[0], new string[0], subject, body, new Attachment[0], isBodyHtml);
            }
        }

        public void Send(string[] toAddresses, string subject, string body, Attachment[] attachments, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(string.Empty, toAddresses, new string[0], new string[0], subject, body, attachments, isBodyHtml);
            }
        }

        public void Send(string[] toAddresses, string[] ccAddresses, string subject, string body, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(string.Empty, toAddresses, ccAddresses, new string[0], subject, body, new Attachment[0], isBodyHtml);
            }
        }

        public void Send(string[] toAddresses, string[] ccAddresses, string subject, string body, Attachment[] attachments,
                         bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(string.Empty, toAddresses, ccAddresses, new string[0], subject, body, attachments, isBodyHtml);
            }
        }

        public void Send(string[] toAddresses, string[] ccAddresses, string[] bccAddresses, string subject, string body,
                         bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(string.Empty, toAddresses, ccAddresses, bccAddresses, subject, body, new Attachment[0], isBodyHtml);
            }
        }

        public void Send(string[] toAddresses, string[] ccAddresses, string[] bccAddresses, string subject, string body,
                         Attachment[] attachments, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(string.Empty, toAddresses, ccAddresses, bccAddresses, subject, body, attachments, isBodyHtml);
            }
        }

        public void Send(string fromAddress, string toAddress, string subject, string body, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(fromAddress, new[] { toAddress }, new string[0], new string[0], subject, body, new Attachment[0], isBodyHtml);
            }
        }

        public void Send(string fromAddress, string toAddress, string subject, string body, Attachment[] attachments,
                         bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(fromAddress, new[]{toAddress}, new string[0], new string[0], subject, body, attachments, isBodyHtml);
            }
        }

        public void Send(string fromAddress, string[] toAddresses, string[] ccAddresses, string subject, string body,
                         bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(fromAddress, toAddresses, ccAddresses, new string[0], subject, body, new Attachment[0], isBodyHtml);
            }
        }

        public void Send(string fromAddress, string[] toAddresses, string[] ccAddresses, string subject, string body,
                         Attachment[] attachments, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(fromAddress, toAddresses, ccAddresses, new string[0], subject, body, attachments, isBodyHtml);
            }
        }

        public void Send(string fromAddress, string[] toAddresses, string[] ccAddresses, string[] bccAddresses, string subject,
                         string body, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                Send(fromAddress, toAddresses, ccAddresses, bccAddresses, subject, body, new Attachment[0], isBodyHtml);
            }
        }

        public void Send(string fromAddress, string[] toAddresses, string[] ccAddresses, string[] bccAddresses, string subject,
                         string body, Attachment[] attachments, bool isBodyHtml = false)
        {
            using (Logger.Assembly.Scope())
            {
                var message = new MailMessage
                    {
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isBodyHtml
                    };

                if (!string.IsNullOrEmpty(fromAddress))
                {
                    message.From = new MailAddress(fromAddress);
                }

                toAddresses.ToList().ForEach(message.To.Add);
                ccAddresses.ToList().ForEach(message.CC.Add);
                bccAddresses.ToList().ForEach(message.Bcc.Add);
 
                attachments.ToList().ForEach(message.Attachments.Add);

                _smtpClient.Send(message);
            }
        }
    }
}