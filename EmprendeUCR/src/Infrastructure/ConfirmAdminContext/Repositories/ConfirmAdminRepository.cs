using EmprendeUCR.Domain.ConfirmAdminContext.Repositories;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Infrastructure.ConfirmAdminContext.Repositories
{
    public class ConfirmAdminRepository : IConfirmAdminRepository
    {
        private readonly ConfirmAdminDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ConfirmAdminRepository(ConfirmAdminDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<ActiveAdministrators> getAdministratorsVoid() {
            return _dbContext.ActiveAdministrators.Where(l => l.Response == false).ToList();
        }

        public async Task<User> getAdminUser(string email) {
            return await _dbContext.User.FirstOrDefaultAsync(c => c.Email.Equals(email));
        }

        public async Task<bool> acceptAdmin(ActiveAdministrators admin) {
            bool updated = false;
            ActiveAdministrators activeAdmin = _dbContext.ActiveAdministrators.Find(admin.Email);
            if (activeAdmin != null)
            {
                activeAdmin.Response = true;
                activeAdmin.Confirm = true;
                activeAdmin.Active = true;

                _dbContext.ActiveAdministrators.Update(activeAdmin);
                await _dbContext.SaveChangesAsync();
                updated = true;
            }
            return updated;
        }
        public async Task<bool> declineAdmin(ActiveAdministrators admin) {
            bool updated = false;
            ActiveAdministrators activeAdmin = _dbContext.ActiveAdministrators.Find(admin.Email);
            if (activeAdmin != null)
            {
                activeAdmin.Response = true;
                activeAdmin.Confirm = false;
                activeAdmin.Active = false;

                _dbContext.ActiveAdministrators.Update(activeAdmin);
                await _dbContext.SaveChangesAsync();
                updated = true;
            }
            return updated;
        }

        public async Task<bool> deteleUser(string email) {
            bool deleted = false;
            User user = _dbContext.User.Find(email);
            if (user != null) 
            {
                _dbContext.User.Remove(user);
                await _dbContext.SaveChangesAsync();
                deleted = true;
            }
            return deleted;
        }
    }
}

