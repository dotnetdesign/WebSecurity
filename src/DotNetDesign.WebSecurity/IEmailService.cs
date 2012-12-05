using System.Net.Mail;

namespace DotNetDesign.WebSecurity
{
    /// <summary>
    /// Email service contract.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string toAddress, string subject, string body, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="attachments">The attachments.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string toAddress, string subject, string body, Attachment[] attachments, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string[] toAddresses, string subject, string body, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="attachments">The attachments.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string[] toAddresses, string subject, string body, Attachment[] attachments, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="ccAddresses">The cc addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string[] toAddresses, string[] ccAddresses, string subject, string body, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="ccAddresses">The cc addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="attachments">The attachments.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string[] toAddresses, string[] ccAddresses, string subject, string body, Attachment[] attachments, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="ccAddresses">The cc addresses.</param>
        /// <param name="bccAddresses">The BCC addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string[] toAddresses, string[] ccAddresses, string[] bccAddresses, string subject, string body, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="ccAddresses">The cc addresses.</param>
        /// <param name="bccAddresses">The BCC addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="attachments">The attachments.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string[] toAddresses, string[] ccAddresses, string[] bccAddresses, string subject, string body, Attachment[] attachments, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string fromAddress, string toAddress, string subject, string body, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="attachments">The attachments.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string fromAddress, string toAddress, string subject, string body, Attachment[] attachments, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="ccAddresses">The cc addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string fromAddress, string[] toAddresses, string[] ccAddresses, string subject, string body, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="ccAddresses">The cc addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="attachments">The attachments.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string fromAddress, string[] toAddresses, string[] ccAddresses, string subject, string body, Attachment[] attachments, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="ccAddresses">The cc addresses.</param>
        /// <param name="bccAddresses">The BCC addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string fromAddress, string[] toAddresses, string[] ccAddresses, string[] bccAddresses, string subject, string body, bool isBodyHtml = false);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="ccAddresses">The cc addresses.</param>
        /// <param name="bccAddresses">The BCC addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="attachments">The attachments.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> the body is html.</param>
        void Send(string fromAddress, string[] toAddresses, string[] ccAddresses, string[] bccAddresses, string subject, string body, Attachment[] attachments, bool isBodyHtml = false);
    }
}