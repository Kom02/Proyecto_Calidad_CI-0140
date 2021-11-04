using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Repositories;

namespace EmprendeUCR.Domain.LoginContext.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> verifyUserType(string email, int userType);
        Task<string> GetPassword(string email);
        EmailConfirmation getEmailConfirmation(string hash_code);
        void updateEmailConfirmation(EmailConfirmation confirmation);
        Task<EmailConfirmation> GetEmailConfirmationByEmail(string email);
        bool CredentialsUpdate(Credentials c);
        Task<ActiveAdministrators> getActiveAdministrator(string email);
        Task<BannedAcount> CheckBanned(string email);
        Task<User> getUser(string email);
        Credentials getCredentials(string email);
    }
}
