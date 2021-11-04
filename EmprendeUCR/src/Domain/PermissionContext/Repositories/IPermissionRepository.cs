using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Domain.PermissionContext.Repositories
{
    public interface IPermissionRepository
    {
        Task<IList<Is_Able_To>> getAllUserPermision();
        Task<IList<Role>> getAllRole();
        Task<IList<Permission>> getAllPermision();
        Task<IList<User>> getAllUser();
        Administrator getAdministrator(string email);
        Client getClient(string email);
        Entrepreneur getEntrepreneur(string email);
        User getUser(string email);
        string getHash(string email);
        string getEmail(string hash);
        Task<IList<Is_Able_To>> getUserPermissions(string email);
        IList<Is_Able_To> getPermissions(string email);
        void addEntry(Is_Able_To newEntry);
        void deleteAllEntries(string email);
        Task addPermissionAsync(Is_Able_To permission);
        Is_Able_To getPermission(string email, int permission, int role);
    }
}
