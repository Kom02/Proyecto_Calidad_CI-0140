using EmprendeUCR.Domain.ConfirmAdminContext.Repositories;
using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.ConfirmAdminContext.Implementations
{
    public class ConfirmAdminService : IConfirmAdminService
    {
        private readonly IConfirmAdminRepository _confirmAdminRepository;

        public ConfirmAdminService(IConfirmAdminRepository ConfirmAdminRepository)
        {
            _confirmAdminRepository = ConfirmAdminRepository;
        }
        public IList<ActiveAdministrators> getAdminitrators() {
            return _confirmAdminRepository.getAdministratorsVoid();
        }

        public async Task<User> getAdmin(string email) {
            return await _confirmAdminRepository.getAdminUser(email);
        }

        public async Task<bool> acceptNewAdmin(ActiveAdministrators admin) {
            return await _confirmAdminRepository.acceptAdmin(admin);
        }

        public async Task<bool> declineNewAdmin(ActiveAdministrators admin){
            return await _confirmAdminRepository.declineAdmin(admin);
        }

        public string getMailBody(int type)
        {
            string url = "";
            string result = "";
            if (type == 1) // ADMINISTRADOR ACEPTADO
            {
                url = "https://localhost:44366/" + "Login?type=Administrator";

                result = string.Format(@"<div style='text-align:center;'>
                                    <h1>EmprendeUCR</h1>
                                    <h3>Hemos aceptado su solicitud como administrador, por favor inicie sesión.</h3>
                                    <a href=" + '"' + url + '"' +
                                   ">Iniciar Sesión</a> </div>", url);
            }

            if (type == 2) // ADMINISTRADOR RECHAZADO
            {

                result = string.Format(@"<div style='text-align:center;'>
                                    <h1>EmprendeUCR</h1>
                                    <h3>Lo sentimos, hemos rechazado su petición de administrador.</h3>");
            }
            return result;
        }

        /*Envía los emails*/
        public async Task<string> sendEmail(Mail mailClass)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailClass.FromMailId);

                    mailClass.ToMailIds.ForEach(x =>
                    {
                        mail.To.Add(x);
                    });

                    mail.Body = mailClass.Body;
                    mail.Subject = mailClass.Subject;
                    mail.IsBodyHtml = mailClass.IsBodyHtml;

                    mailClass.Attachements.ForEach(x =>
                    {
                        mail.Attachments.Add(new Attachment(x));
                    });

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(mailClass.FromMailId, mailClass.FromMailIdPassword);
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mail);
                        return "Mensaje enviado";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<bool> deteleUserAdmin(string email) 
        {
            return await _confirmAdminRepository.deteleUser(email);
        }
    }
}