using System;
using System.Threading.Tasks;
using EmprendeUCR.Domain.LoginContext.Repositories;
using System.IO;
using System.Security.Cryptography;
using EmprendeUCR.Domain.Core.CoreEntities;
using System.Text;
using System.Net.Mail;

namespace EmprendeUCR.Application.LoginContext.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        byte[] Key = { 55, 44, 195, 55, 222, 61, 56, 207, 192, 137, 79, 77, 80, 84, 123, 53, 41, 123, 159, 185, 44, 179, 112, 237, 85, 82, 226, 66, 122, 186, 204, 185 };
        byte[] IV = { 186, 64, 237, 198, 188, 85, 101, 152, 93, 165, 235, 75, 123, 140, 67, 216 };

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<bool> verifyTypeUser(string email, int userType)
        {
            return await _loginRepository.verifyUserType(email, userType);
        }

        public string encryptPassword(string password)
        {
            string encriptPassword = "";

            if (!string.IsNullOrEmpty(password))
            {
                byte[] encrypt = encryptStringToBytes_Aes(password, Key, IV);
                encriptPassword = Convert.ToBase64String(encrypt);
            }
            return encriptPassword;
        }

        public byte[] encryptStringToBytes_Aes(string password, byte[] Key, byte[] IV)
        {
            if (password == null || password.Length <= 0)
                throw new ArgumentNullException("password");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(password);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        public async Task<string> GetPasswordAsync(string email)
        {
            return await _loginRepository.GetPassword(email);
        }

        public EmailConfirmation getEmailConfirmationByHash(string hash_code)
        {
            return  _loginRepository.getEmailConfirmation(hash_code);
        }

        public string hashEmail(string email)
        {
            string hashEmail = "";
            if (string.IsNullOrEmpty(email))
            {
                hashEmail = "";
            }
            else
            {
                string salt = getSalt();
                var passwordBytes = Encoding.UTF8.GetBytes(salt + email);
                hashEmail = Convert.ToBase64String(passwordBytes);
            }
            return hashEmail;
        }

        /*Crea una sal*/
        public string getSalt()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[15];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            string finalString = new String(stringChars);
            return finalString;
        }

        public void updateEmailConfirmations(EmailConfirmation confirmation) 
        {
            _loginRepository.updateEmailConfirmation(confirmation);
        }

        public string getMailBody(string hash_mail, int type_user)
        {
            string url = "";
            string result = "";
            if (type_user == 1) // CLIENT CREATION
            {
                url = "https://localhost:44366/" + "RegistrationData?email=" + hash_mail + "&type=Client";

                result = string.Format(@"<div style='text-align:center;'>
                                    <h1>Bienvenido a EmprendeUCR</h1>
                                    <h3>Haga click sobre el link debajo para registrarse como cliente</h3>
                                    <a href=" + '"' + url + '"' +
                                   ">Confirmar email</a> </div>", url, hash_mail);
            }
            if (type_user == 2) // ENTREPENEUR CREATION
            {
                url = "https://localhost:44366/" + "registrationData?email=" + hash_mail + "&type=Entrepreneur";

                result = string.Format(@"<div style='text-align:center;'>
                                    <h1>Bienvenido a EmprendeUCR</h1>
                                    <h3>Haga click sobre el link debajo para registrarse como emprendedor</h3>
                                    <a href=" + '"' + url + '"' +
                                   ">Confirmar email</a> </div>", url, hash_mail);
            }
            if (type_user == 3) // ADMINISTRATOR CREATION
            {
                url = "https://localhost:44366/" + "registrationData?email=" + hash_mail + "&type=Administrator";

                result = string.Format(@"<div style='text-align:center;'>
                                    <h1>Bienvenido a EmprendeUCR</h1>
                                    <h3>Haga click sobre el link debajo para registrarse como administrador</h3>
                                    <a href=" + '"' + url + '"' +
                                   ">Confirmar email</a> </div>", url, hash_mail);
            }
            return result;
        }

        public async Task<EmailConfirmation> GetEmailConfirmationEmail(string email)
        {
            return await _loginRepository.GetEmailConfirmationByEmail(email);
        }

        public async Task<string> SendMail(Mail mailClass)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailClass.FromMailId);

                    mailClass.ToMailIds.ForEach(x =>
                    {
                        Console.WriteLine(x);
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

        public string GetNewPasswordMail(string hash)
        {
            string url = "";
            string result = "";

            url = "https://localhost:44366/" + "NewPassword?email=" + hash;

            result = string.Format(@"<div style='text-align:center;'>
                                <h1>Recuperación de contraseña</h1>
                                <h3>Haga click sobre el link debajo para cambiar a una nueva contraseña.</h3>
                                <p>Si no ha solicitado un cambio de contraseña omita este correo</p>
                                <a href=" + '"' + url + '"' +
                                ">Cambiar contraseña</a> </div>", url, hash);

            return result;
        }

        public bool UpdateCredentials(Credentials c)
        {
            return _loginRepository.CredentialsUpdate(c);
        }

        public async Task<ActiveAdministrators> getActiveAdministrators(string email) 
        {
            return await _loginRepository.getActiveAdministrator(email);
        }

        public async Task<string> GetBannedMessage(string email)
        {
            string bannedMessage = string.Empty;
            var userBanned = await _loginRepository.CheckBanned(email);
            if (!(userBanned == null)) // Is banned
            {
                if (userBanned.Type == 1) // Is total banned
                {
                    bannedMessage = "Su cuenta se encuentra baneando indefinidamente";
                }
                else if (userBanned.FinishDate > DateTime.Now) // Is partial banned
                {
                    bannedMessage = "Su cuenta esta baneado temporalemte, faltan:"
                        + (userBanned.FinishDate - DateTime.Now).Days + "días";
                }
            }
            return bannedMessage;
        }

        public async Task<User> getUserByEmail(string email) 
        {
            return await _loginRepository.getUser(email);
        }

        public Credentials getUserCredentials(string email) 
        {
            return _loginRepository.getCredentials(email);
        }
    }
}
