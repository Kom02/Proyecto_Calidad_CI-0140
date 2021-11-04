using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.RegisterContext.Repositories;
using System;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using EmprendeUCR.Domain.RegisterContext.Entities;
using System.Collections.Generic;

namespace EmprendeUCR.Application.RegisterContext.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _RegisterRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            _RegisterRepository = registerRepository;
        }


        byte[] Key = { 55, 44, 195, 55, 222, 61, 56, 207, 192, 137, 79, 77, 80, 84, 123, 53, 41, 123, 159, 185, 44, 179, 112, 237, 85, 82, 226, 66, 122, 186, 204, 185 };
        byte[] IV = { 186, 64, 237, 198, 188, 85, 101, 152, 93, 165, 235, 75, 123, 140, 67, 216 };

        /*Crea un nuevo usuarios*/
        public async Task<bool> insertNewUser(User user) 
        {
            return await _RegisterRepository.addUserAsync(user);
        }

        public bool verifyUserExistence(Register newRegister) 
        {
            return _RegisterRepository.verifyUserRecord(newRegister);
        }

        /*Crea una nueva credencial*/
        public async Task<bool> insertNewCredentials(Credentials credentials) 
        {
            return await _RegisterRepository.addCredentialsAsync(credentials);
        }

        /*Crea una nueva confirmación de email*/
        public async Task<bool> insertNewEmailConfirmation(EmailConfirmation emailConfirmation) 
        {
            return await _RegisterRepository.addEmailConfirmationAsync(emailConfirmation);
        }

        /*Retorna el body del email*/
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

        /*HashEmail*/
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

        /*Encrypta las contraseñas*/
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

        /*Encrypta las contraseñas*/
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

        /*Retorna categorias padre*/
        public async Task<IList<Category>> getCategoryParents()
        {
            return await _RegisterRepository.getParents();
        }

        /*Muestra categorias hijas*/
        public async Task<IList<Category>> getChildrenOfCategory(int id) 
        {
            return await _RegisterRepository.getChildrenOf(id);
        }

        /*Verifica el email confirmation*/
        public async Task<EmailConfirmation> getEmailConfirmation(string hash_code) 
        {
            return await _RegisterRepository.getConfirmationEmail(hash_code);
        }

        public async Task<bool> getUserConfirmationEmail(string email) 
        {
            return await _RegisterRepository.getUserConfirmEmail(email);
        }

        /*Returns TRUE if the email is expired*/
        public bool verifyExpirationDate(EmailConfirmation email)
        {
            bool verify = false;
            DateTime fecha = DateTime.Now;
            if (email.Expiration_Date < fecha)
            {
                verify = true;
            }
            return verify;
        }

        public async Task<IList<Province>> listProvinces() 
        {
            return await _RegisterRepository.getAllProvinces();
        }

        public async Task<IList<District>> listDistricts()
        {
            return await _RegisterRepository.getAllDistricts();
        }

        public async Task<IList<Canton>> listCantons()
        {
            return await _RegisterRepository.getAllCantons();
        }

        public async Task<IList<Category>> listCategories() 
        {
            return await _RegisterRepository.getAllCategories();
        }

        public async Task<bool> insertNewPhone(Phones phone) 
        {
            return await _RegisterRepository.addPhoneAsync(phone);
        }

        public async Task<bool> updateUser(User user) 
        {
            return await _RegisterRepository.updateUserAsync(user);
        }

        public async Task<bool> insertNewMember(Members members) 
        {
            return await _RegisterRepository.addMembersAsync(members);
        }

        public async Task<bool> insertNewClient(Client client) 
        {
            return await _RegisterRepository.addClientAsync(client);
        }

        public async Task<bool> insertNewShoppingCart(ShoppingCart shoppingcart) 
        {
            return await _RegisterRepository.addShoppingCartAsync(shoppingcart);
        }

        public async Task<bool> insertNewLike(Likes like) 
        {
            return await _RegisterRepository.addLikesAsync(like);
        }

        public async Task<bool> insertNewEntrepreneur(Entrepreneur entrepreneur) 
        {
            return await _RegisterRepository.addEntrepreneurAsync(entrepreneur);
        }

        public async Task<bool> insertNewAdministrator(Administrator administrator) 
        {
            return await _RegisterRepository.addAdministratorAsync(administrator);
        }

        public IList<Canton> getListCantonsByProvince(string province) 
        {
            return _RegisterRepository.getListCantons(province);
        }

        public IList<District> getListDistrictsByCanton(string canton) 
        {
            return _RegisterRepository.getListDistrics(canton);
        }

        public async Task<bool> addNewActiveAdministrator(ActiveAdministrators activeAdministrator)
        {
            return await _RegisterRepository.addActiveAdministrator(activeAdministrator);
        }

        public async Task<bool> verifyPastAdminRegister(string email) 
        {
            return await _RegisterRepository.verifyPastAdmin(email);
        }

        public bool AddLikes(Likes l)
        {
            return _RegisterRepository.AddMemberLikes(l);
        }

        public bool verifyUserTypes(string email, int userType) 
        {
            return _RegisterRepository.verifyUserType(email, userType);
        }
        public EmailConfirmation getEmailConfirmationByEmail(string email) 
        {
            return _RegisterRepository.getEmailConfirmation(email);
        }
        public async Task<string> getUserPassword(string email) 
        {
            return await _RegisterRepository.GetPassword(email);
        }

        public async Task<bool> verifyMembersExistence(string email)
        {
            return await _RegisterRepository.verifyMembers(email);
        }
    }
}
