using System;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.LoginContext.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.LoginContext.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly LoginDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public LoginRepository(LoginDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> verifyUserType(string email, int userType)
        {
            bool exists = false;

            switch (userType)
            {
                case 1:
                    if (await _dbContext.Client.FindAsync(email) != null)
                    {
                        exists = true;
                    }
                    break;

                case 2:
                    if (await _dbContext.Entrepreneur.FindAsync(email) != null)
                    {
                        exists = true;
                    }
                    break;

                case 3:
                    if (await _dbContext.Administrator.FindAsync(email) != null)
                    {
                        exists = true;
                    }
                    break;
            }
            return exists;
        }

        public async Task<string> GetPassword(string email)
        {
            Credentials credentials = await _dbContext.Credentials.FirstOrDefaultAsync(c => c.User_Email.Equals(email));
            if (credentials == null)
            {
                return "";
            }
            else
            {
                return credentials.Password.ToString();
            }
        }

        public async Task<EmailConfirmation> GetEmailConfirmationByEmail(string email)
        {
            return await _dbContext.EmailConfirmation.FirstOrDefaultAsync(c => c.Email.Equals(email));
        }

        public EmailConfirmation getEmailConfirmation(string hash_code)
        {
            return _dbContext.EmailConfirmation.FirstOrDefault(c => c.Hash_Code.Equals(hash_code));
        }

        public void updateEmailConfirmation(EmailConfirmation confirmation)
        {
            EmailConfirmation email_confirmation = _dbContext.EmailConfirmation.FirstOrDefault(c => c.Email.Equals(confirmation.Email));
            if (email_confirmation != null)
            {
                email_confirmation.Email = confirmation.Email;
                email_confirmation.Hash_Code = confirmation.Hash_Code;
                email_confirmation.Creation_Date = confirmation.Creation_Date;
                email_confirmation.Expiration_Date = confirmation.Expiration_Date;
                _dbContext.Update(email_confirmation);
                _dbContext.SaveChanges();
            }
        }

        public bool CredentialsUpdate(Credentials c)
        {
            Credentials credentials = _dbContext.Credentials.FirstOrDefault(c => c.User_Email.Equals(c.User_Email));
            if (credentials != null)
            {
                _dbContext.Update(c);
                _dbContext.SaveChanges();

            }
            return true;
        }

        public async Task<ActiveAdministrators> getActiveAdministrator(string email) 
        {
            return await _dbContext.ActiveAdministrators.FirstOrDefaultAsync(c => c.Email.Equals(email));
        }

        public async Task<BannedAcount> CheckBanned(string email)
        {
            return await _dbContext.BannedAcount.FirstOrDefaultAsync(c => c.UserEmail.Equals(email));
        }

        public async Task<User> getUser(string email) 
        {
            return await _dbContext.User.FindAsync(email);
        }

        public Credentials getCredentials(string email) 
        {
            return _dbContext.Credentials.Find(email);
        }
    }
}
