using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.PermissionContext
{
    public interface IPermissionService
    {
        Task<IList<Is_Able_To>> getAllUserPermisions();
        Task<IList<Role>> getAllRoles();
        Task<IList<Permission>> getAllPermisions();
        Task<IList<User>> getAllUsers();
        Administrator getAdministrator(string email);
        Client getClient(string email);
        Entrepreneur getEntrepreneur(string email);
        User getUserByEmail(string email);
        string getHashByEmail(string email);
        string getEmailByHash(string hash);
        Task<IList<Is_Able_To>> getPermissionsByUser(string email);
        void updateUserPermissions(string email, IList<Is_Able_To> permissions);
        Task addPermission(Is_Able_To permission);
        Is_Able_To searchPermission(string email, int permission, int role);
    }
}
