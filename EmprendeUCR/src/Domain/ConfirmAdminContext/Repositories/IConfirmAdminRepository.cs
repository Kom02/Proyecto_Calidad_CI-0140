using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Domain.ConfirmAdminContext.Repositories
{
    public interface IConfirmAdminRepository
    {
        IList<ActiveAdministrators> getAdministratorsVoid();
        Task<User> getAdminUser(string email);
        Task<bool> acceptAdmin(ActiveAdministrators admin);
        Task<bool> declineAdmin(ActiveAdministrators admin);
        Task<bool> deteleUser(string email);
    }
}
