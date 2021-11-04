using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.RegisterContext.Entities;
using EmprendeUCR.Domain.RegisterContext.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Infrastructure.RegisterContext.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly RegisterDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public RegisterRepository(RegisterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> addUserAsync(User user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool verifyUserRecord(Register newRegister)
        {
            bool exists = false;
            User _user = _dbContext.User.Find (newRegister.Email);
            if (_user != null)
            {
                exists = true;
            }
            return exists;
        }

        public async Task<bool> addCredentialsAsync(Credentials credentials)
        {
            await _dbContext.Credentials.AddAsync(credentials);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> addEmailConfirmationAsync(EmailConfirmation emailConfirmation)
        {
            await _dbContext.EmailConfirmation.AddAsync(emailConfirmation);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> addPhoneAsync(Phones phones)
        {
            await _dbContext.Phones.AddAsync(phones);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Category>> getParents()
        {
            return await _dbContext.Category.FromSqlRaw("SELECT * FROM Category WHERE ParentId IS NULL").ToListAsync();
        }

        public async Task<IList<Category>> getChildrenOf(int parentId)
        {
            return await _dbContext.Category.FromSqlRaw("SELECT * FROM Category WHERE ParentId = " + parentId).ToListAsync();
        }

        public async Task<EmailConfirmation> getConfirmationEmail(string hash_code) 
        {
            return await _dbContext.EmailConfirmation.FirstOrDefaultAsync(c => c.Hash_Code.Equals(hash_code));
        }

        public async Task<bool> getUserConfirmEmail(string email) 
        {
            bool confirmado = false;
            User user = await _dbContext.User.FirstOrDefaultAsync(c => c.Email.Equals(email));
            if (user != null)
            {
                confirmado = (bool)user.Email_Confirmation;
            }
            return confirmado;
        }

        public async Task<IList<District>> getAllDistricts() 
        {
            return await _dbContext.District.ToListAsync();
        }

        public async Task<IList<Canton>> getAllCantons()
        {
            return await _dbContext.Canton.ToListAsync();
        }

        public async Task<IList<Province>> getAllProvinces()
        {
            return await _dbContext.Province.ToListAsync();
        }

        public async Task<IList<Category>> getAllCategories() 
        { 
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<bool> updateUserAsync(User _user) 
        {
            bool updated = false;
            User user = await _dbContext.User.FirstOrDefaultAsync(c => c.Email.Equals(_user.Email));
            if (user != null)
            {
                user.Province_Name = _user.Province_Name;
                user.Canton_Name = _user.Canton_Name;
                user.District_Name = _user.District_Name;

                user.Photo = _user.Photo;

                user.Name = _user.Name;
                user.F_Last_Name = _user.F_Last_Name;
                user.S_Last_Name = _user.S_Last_Name;

                user.Birth_Date = _user.Birth_Date;
                user.Email_Confirmation = _user.Email_Confirmation;

                _dbContext.Update(user);
                await _dbContext.SaveChangesAsync();
                updated = true;
            }
            return updated; 
        }

        public async Task<bool> addMembersAsync(Members members) 
        {
            await _dbContext.Members.AddAsync(members);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> addClientAsync(Client client) 
        {
            await _dbContext.Client.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> addShoppingCartAsync(ShoppingCart shoppingCart) 
        {
            await _dbContext.ShoppingCart.AddAsync(shoppingCart);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> addLikesAsync(Likes likes) 
        {
            await _dbContext.Likes.AddAsync(likes);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> addEntrepreneurAsync(Entrepreneur entrepreneur) 
        {
            await _dbContext.Entrepreneur.AddAsync(entrepreneur);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> addAdministratorAsync(Administrator administrator) 
        {
            await _dbContext.Administrator.AddAsync(administrator);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IList<Canton> getListCantons(string province) 
        {
            return _dbContext.Canton.FromSqlRaw("exec GetCantons @province =\"" + province + "\"").ToArray();
        }

        public IList<District> getListDistrics(string canton) 
        { 
            return _dbContext.District.FromSqlRaw("exec GetDistricts @canton =\"" + canton + "\"").ToArray();
        }

        public async Task<bool> addActiveAdministrator(ActiveAdministrators activeAdministrator)
        {
            await _dbContext.ActiveAdministrators.AddAsync(activeAdministrator);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool AddMemberLikes(Likes l)
        {
            _dbContext.Likes.Add(l);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<bool> verifyPastAdmin(string email) 
        {
            bool Admin = false;
            ActiveAdministrators activeAdmin = await _dbContext.ActiveAdministrators.FindAsync(email);
            if (activeAdmin != null) 
            {
                Admin = true;
            }
            return Admin;
        }

        public bool verifyUserType(string email, int userType)
        {
            bool exists = false;
            switch (userType)
            {
                case 1:
                    if (_dbContext.Client.Find(email) != null)
                    {
                        exists = true;
                    }
                    break;

                case 2:
                    if (_dbContext.Entrepreneur.Find(email) != null)
                    {
                        exists = true;
                    }
                    break;

                case 3:
                    if (_dbContext.Administrator.Find(email) != null)
                    {
                        exists = true;
                    }
                    break;
            }
            return exists;
        }

        public EmailConfirmation getEmailConfirmation(string email) 
        {
            return _dbContext.EmailConfirmation.Find(email);
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

        public async Task<bool> verifyMembers(string email) 
        {
            Members findMember = await _dbContext.Members.FindAsync(email);
            if (findMember == null) 
            {
                return false;
            }
            return true;
        }
    }
}