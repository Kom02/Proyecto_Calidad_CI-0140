using EmprendeUCR_WebApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
/* Manfred Carvajal - Luis Rojas
 * mejorar el correo de confirmaciion cuando se registra un usuario por primera
 * vez 
 * crear funcionalidad de contraseña olvidada
 */

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class MailService
    {
         /*Brief: prints the welcome message and confirmation link in the email
         * Param: hash mail to uniquely identify it and type user to identify 
         * the type of account
         * Returns: string, the message to print in the email
         */
        public string getMailBody(string hash_mail, int type_user)
        {
            string url = "";
            string result = "";
            if (type_user == 1) // CLIENT CREATION
            {
                Console.WriteLine(type_user);
                url = Global.DomainName + "RegistrationData?email=" + hash_mail + "&type=Client";

                result = string.Format(@"<div style='text-align:center;'>
                                    <h1>Bienvenido a EmprendeUCR</h1>
                                    <h3>Haga click sobre el link debajo para registrarse como cliente(a)</h3>
                                    <a href=" + '"' + url + '"' +
                                   ">Confirmar email</a> </div>", url, hash_mail);
            }
            if (type_user == 2) // ENTREPENEUR CREATION
            {
                Console.WriteLine(type_user);
                url = Global.DomainName + "registrationData?email=" + hash_mail + "&type=Entrepreneur";

                result = string.Format(@"<div style='text-align:center;'>
                                    <h1>Bienvenido a EmprendeUCR</h1>
                                    <h3>Haga click sobre el link debajo para registrarse como emprendedor(a)</h3>
                                    <a href=" + '"' + url + '"' +
                                   ">Confirmar email</a> </div>", url, hash_mail);
            }
            if (type_user == 3) // ADMINISTRATOR CREATION
            {
                Console.WriteLine(type_user);
                url = Global.DomainName + "registrationData?email=" + hash_mail + "&type=Administrator";

                result = string.Format(@"<div style='text-align:center;'>
                                    <h1>Bienvenido a EmprendeUCR</h1>
                                    <h3>Haga click sobre el link debajo para registrarse como administrador(a)</h3>
                                    <a href=" + '"' + url + '"' +
                                   ">Confirmar email</a> </div>", url, hash_mail);
            }

            return result;
           
        }

         /*Brief: prints the new password message and confirmation link in the
         * email
         * Param: hash mail to uniquely identify it
         * Returns: string, the message to print in the email
         */
        public string getNewPasswordMail(string hash_mail)
        {
            string url = "";
            string result = "";

            url = Global.DomainName + "NewPassword?email=" + hash_mail;

            result = string.Format(@"<div style='text-align:center;'>
                                <h1>Recuperación de contraseña</h1>
                                <h3>Haga click sobre el link debajo para cambiar a una nueva contraseña.</h3>
                                <p>Si no ha solicitado un cambio de contraseña omita este correo</p>
                                <a href=" + '"' + url + '"' +
                                ">Cambiar contraseña</a> </div>", url, hash_mail);

            
            return result;
        }

        /*Brief: sends an email when need it
         * email
         * Param: mail object
         * Returns: async, string task
         */
        public async Task<string> SendMail(Mail mailClass)
        {
            try
            {
                using (MailMessage mail = new MailMessage()) {
                    mail.From = new MailAddress(mailClass.FromMailId);
                    Console.WriteLine(mail.From);
                    mailClass.ToMailIds.ForEach(x =>
                    {
                        Console.WriteLine(x);
                        mail.To.Add(x);
                    });

                    mail.Body = mailClass.Body;
                    Console.WriteLine(mail.Subject);
                    mail.Subject = mailClass.Subject;
                    mail.IsBodyHtml = mailClass.IsBodyHtml;

                    mailClass.Attachements.ForEach(x =>
                    {
                        mail.Attachments.Add(new Attachment(x));
                    });

                    using (SmtpClient smtp = new SmtpClient ("smtp.gmail.com", 587)) 
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
    }
}
