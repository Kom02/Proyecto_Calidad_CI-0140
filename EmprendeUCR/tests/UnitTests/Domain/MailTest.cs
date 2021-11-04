using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class MailTest
    {
        [Fact]
        public void TryCreateMail()
        {
            string fromMailId = "emprende.ucr@gmail.com";
            string fromMailIdPassword = "ingebases21";
            //todo: list toMailsID
            string subject = "subject";
            string body = "body";
            bool isBodyHtml = true;
            //todo: list attachments

            Mail mail = new Mail
            {
                FromMailId = fromMailId,
                FromMailIdPassword = fromMailIdPassword,
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            };
            Assert.True(fromMailId == mail.FromMailId, "The member fromMailId is not the same");
            Assert.True(fromMailIdPassword == mail.FromMailIdPassword, "The member fromMailIdPassword is not the same");
            Assert.True(subject == mail.Subject, "The member subject is not the same");
            Assert.True(body == mail.Body, "The member body is not the same");
            Assert.True(isBodyHtml == mail.IsBodyHtml, "The member isBodyHtml is not the same");
        }
    }
}

/*Manfred Carvajal Masis - B81688 Pruebas de Unidad e Integración.
Mail tests.*/
