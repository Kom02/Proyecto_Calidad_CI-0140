using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.ConfirmAdminContext
{
    public interface IConfirmAdminService
    {
        IList<ActiveAdministrators> getAdminitrators();
        Task<User> getAdmin(string email);
        Task<bool> acceptNewAdmin(ActiveAdministrators admin);
        Task<bool> declineNewAdmin(ActiveAdministrators admin);
        string getMailBody(int type_user);
        Task<string> sendEmail(Mail mailClass);
        Task<bool> deteleUserAdmin(string email);
    }
}