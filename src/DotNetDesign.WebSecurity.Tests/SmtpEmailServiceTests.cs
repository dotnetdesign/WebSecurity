using System.Linq;
using System.Net.Mail;
using FluentAssertions;
using Moq;
using Xunit;
using Xunit.Extensions;

namespace DotNetDesign.WebSecurity.Tests
{
    public class SmtpEmailServiceTests
    {
        private readonly string _subject = "Subject";
        private readonly string _body = "Body";
        private readonly string _from = "from@example.com";
        private readonly string _to = "to@example.com";
        private readonly string _cc = "cc@example.com";
        private readonly string _bcc = "bcc@example.com";
        private readonly Attachment _attachment = new Attachment("attachment.txt");

        [Fact]
        public void FirstSignature()
        {
            var mockSmtpClient = new Mock<ISmtpClient>();
            var emailService = new SmtpEmailService(mockSmtpClient.Object);

            mockSmtpClient.Setup(x => x.Send(It.IsAny<MailMessage>())).Callback((MailMessage mailMessage) =>
            {
                mailMessage.To.Any(x => x.Address == _to).Should().BeTrue();
                mailMessage.Subject.Should().Be(_subject);
                mailMessage.Body.Should().Be(_body);
                mailMessage.IsBodyHtml.Should().BeFalse();
            });

            emailService.Send(_to, _subject, _body);
            mockSmtpClient.VerifyAll();


            mockSmtpClient.Setup(x => x.Send(It.IsAny<MailMessage>())).Callback((MailMessage mailMessage) =>
            {
                mailMessage.To.Any(x => x.Address == _to).Should().BeTrue();
                mailMessage.Subject.Should().Be(_subject);
                mailMessage.Body.Should().Be(_body);
                mailMessage.IsBodyHtml.Should().BeTrue();
            });

            emailService.Send(_to, _subject, _body, true);
            mockSmtpClient.VerifyAll();


            mockSmtpClient.Setup(x => x.Send(It.IsAny<MailMessage>())).Callback((MailMessage mailMessage) =>
            {
                mailMessage.To.Any(x => x.Address == _to).Should().BeTrue();
                mailMessage.Subject.Should().Be(_subject);
                mailMessage.Body.Should().Be(_body);
                mailMessage.IsBodyHtml.Should().BeFalse();
                mailMessage.Attachments.Any(x => x == _attachment).Should().BeTrue();
            });

            emailService.Send(_to, _subject, _body, new[] { _attachment });
            mockSmtpClient.VerifyAll();


            mockSmtpClient.Setup(x => x.Send(It.IsAny<MailMessage>())).Callback((MailMessage mailMessage) =>
            {
                mailMessage.To.Any(x => x.Address == _to).Should().BeTrue();
                mailMessage.Subject.Should().Be(_subject);
                mailMessage.Body.Should().Be(_body);
                mailMessage.IsBodyHtml.Should().BeTrue();
                mailMessage.Attachments.Any(x => x == _attachment).Should().BeTrue();
            });

            emailService.Send(_to, _subject, _body, new[] { _attachment }, true);
            mockSmtpClient.VerifyAll();


            mockSmtpClient.Setup(x => x.Send(It.IsAny<MailMessage>())).Callback((MailMessage mailMessage) =>
            {
                mailMessage.To.Any(x => x.Address == _to).Should().BeTrue();
                mailMessage.Subject.Should().Be(_subject);
                mailMessage.Body.Should().Be(_body);
                mailMessage.IsBodyHtml.Should().BeFalse();
            });

            emailService.Send(new[] {_to}, _subject, _body);
            mockSmtpClient.VerifyAll();
        }
    }
}