using EmprendeUCR.Domain.Core.CoreEntities;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Application.LoginContext
{
    public interface ILoginService
    {
        Task<bool> verifyTypeUser(string email, int userType);
        string encryptPassword(string password);
        byte[] encryptStringToBytes_Aes(string password, byte[] Key, byte[] IV);
        Task<string> GetPasswordAsync(string email);
        EmailConfirmation getEmailConfirmationByHash(string hash_code);
        string hashEmail(string email);
        string getSalt();
        void updateEmailConfirmations(EmailConfirmation confirmation);
        string getMailBody(string hash_mail, int type_user);
        Task<EmailConfirmation> GetEmailConfirmationEmail(string email);
        Task<string> SendMail(Mail m);
        string GetNewPasswordMail(string hash);
        bool UpdateCredentials(Credentials c);
        Task<ActiveAdministrators> getActiveAdministrators(string email);
        Task<string> GetBannedMessage(string email);
        Task<User> getUserByEmail(string email);
        Credentials getUserCredentials(string email);
    }
}
