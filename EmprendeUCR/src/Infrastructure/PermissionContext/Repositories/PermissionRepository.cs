using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PermissionContext.Repositories;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.PermissionContext.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly PermissionDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public PermissionRepository(PermissionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Is_Able_To>> getAllUserPermision() 
        {
            return await _dbContext.Is_Able_To.ToListAsync();
        }

        public async Task<IList<Role>> getAllRole() 
        {
            return await _dbContext.Role.ToListAsync();
        }

        public async Task<IList<Permission>> getAllPermision() 
        {
            return await _dbContext.Permission.ToListAsync();
        }

        public async Task<IList<User>> getAllUser()
        {
            return await _dbContext.User.ToListAsync();
        }

        public Administrator getAdministrator(string email)
        {
            return _dbContext.Administrator.FirstOrDefault(e => e.User_Email.Equals(email));
        }

        public Client getClient(string email)
        {
            return _dbContext.Client.FirstOrDefault(e => e.User_Email.Equals(email));
        }

        public Entrepreneur getEntrepreneur(string email)
        {
            return _dbContext.Entrepreneur.FirstOrDefault(e => e.User_Email.Equals(email));
        }

        public User getUser(string email) 
        {
            return _dbContext.User.FirstOrDefault(e => e.Email.Equals(email));
        }
        
        public string getHash(string email)
        {
            EmailConfirmation emailConfirmation = _dbContext.EmailConfirmation.FirstOrDefault(c => c.Email.Equals(email));
            return emailConfirmation.Hash_Code;
        }

        public string getEmail(string hash)
        {
            EmailConfirmation emailConfirmation = _dbContext.EmailConfirmation.FirstOrDefault(c => c.Hash_Code.Equals(hash));
            return emailConfirmation.Email;
        }

        public async Task<IList<Is_Able_To>> getUserPermissions(string email)
        {
            return await _dbContext.Is_Able_To.FromSqlRaw("SELECT * FROM Is_Able_To WHERE Email = '" + email + "'").ToArrayAsync();
        }

        public IList<Is_Able_To> getPermissions(string email)
        {
            return _dbContext.Is_Able_To.FromSqlRaw("SELECT * FROM Is_Able_To WHERE Email = '" + email + "'").ToArray();
        }

        public void addEntry(Is_Able_To newEntry)
        {
            _dbContext.Is_Able_To.Add(newEntry);
            _dbContext.SaveChanges();
        }

        public void deleteAllEntries(string email)
        {
            _dbContext.Is_Able_To.RemoveRange(this.getPermissions(email));
            _dbContext.SaveChanges();
        }

        public async Task addPermissionAsync(Is_Able_To permission)
        {
            await _dbContext.Is_Able_To.AddAsync(permission);
            await _dbContext.SaveChangesAsync();
        }

        public Is_Able_To getPermission(string email, int permission, int role)
        {
            return _dbContext.Is_Able_To.FirstOrDefault(c => c.Email.Equals(email) &&
                    c.Permission_Id == permission && c.Role_Id == role);
        }
    }
}
