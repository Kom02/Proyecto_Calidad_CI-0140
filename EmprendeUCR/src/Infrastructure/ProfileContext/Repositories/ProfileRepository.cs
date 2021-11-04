using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.ProfileContext.Repositories;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR.Domain.Reports.Entities;
using EmprendeUCR.Application.Reports.Implementations;

namespace EmprendeUCR.Infrastructure.ProfileContext.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfileDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ProfileRepository(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _dbContext.User.FindAsync(email);
        }
        public  async Task<IList<Entrepreneur>> GetUsersAsync()
        {
            return await _dbContext.Entrepreneur.ToListAsync();
        }

        public async Task<Members> GetMemberAsync(string email)
        {
            return await _dbContext.Members.FindAsync(email);
        }

        public async Task<Client> GetClientAsync(string email)
        {
            return await _dbContext.Client.FindAsync(email);
        }

        public async Task<Entrepreneur> GetEntrepreneurAsync(string email)
        {
            return await _dbContext.Entrepreneur.FindAsync(email);
        }

        public async Task<Administrator> GetAdministratorAsync(string email)
        {
            return await _dbContext.Administrator.FindAsync(email);
        }

        public async Task<IList<Likes>> GetLikes(string email)
        {
            return await _dbContext.Likes.Where(l => String.Equals(l.Members_Email, email)).ToListAsync();
        }

        public async Task<Phones> GetPhoneAsync(string email)
        {
            return await _dbContext.Phones.FindAsync(email);
        }

        public string GetCategoryTitleAsync(int categoryId)
        {
            return _dbContext.Category.Find(categoryId).Title;
        }

        public IList<Category> GetFatherCategories()
        {
            return _dbContext.Category.FromSqlRaw("SELECT * FROM Category WHERE ParentId IS NULL").ToArray();
        }

        public IList<Category> GetChildCategories(int parentId)
        {
            return _dbContext.Category.FromSqlRaw("SELECT * FROM Category WHERE ParentId = " + parentId).ToArray();
        }

        public IList<Category> GetAllCategories()
        {
            return _dbContext.Category.ToList();
        }

        public IList<Province> GetAllProvinces()
        {
            return _dbContext.Province.ToList();
        }

        public IList<Canton> GetProvinceCantons(string province)
        {
            return _dbContext.Canton.FromSqlRaw("exec GetCantons @province =\"" + province + "\"").ToArray();
        }

        public IList<District> GetCantonDistricts(string canton)
        {
            return _dbContext.District.FromSqlRaw("exec GetDistricts @canton =\"" + canton + "\"").ToArray();
        }

        public async Task<bool> PhoneUpdate(string email, string phone)
        {
            Phones UserPhone = _dbContext.Phones.FirstOrDefault(c => c.User_Email.Equals(email));
            if (UserPhone != null)
            {
                UserPhone.Phone_Number = phone;
                _dbContext.Phones.Update(UserPhone);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UserUpdate(User u)
        {
            User user = _dbContext.User.FirstOrDefault(c => c.Email.Equals(u.Email));
            if (user != null)
            {
                _dbContext.Update(user);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> AdministratorUpdate(Administrator a)
        {
            _dbContext.Administrator.Update(a);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MemberUpdate(Members m)
        {
            _dbContext.Members.Update(m);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClientUpdate(Client c)
        {
            _dbContext.Client.Update(c);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EntrepreneurUpdate(Entrepreneur e)
        {
            _dbContext.Entrepreneur.Update(e);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddMemberLikes(Likes l)
        {
            _dbContext.Likes.Add(l);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveMemberLikes(Likes l)
        {
            _dbContext.Likes.Remove(l);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddReport(Report r) {
            _dbContext.Report.Add(r);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveReport(Report r)
        {
            _dbContext.Report.Remove(r);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
