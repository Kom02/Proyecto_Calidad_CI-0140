using EmprendeUCR.Domain.PermissionContext.Repositories;
using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.PermissionContext.Implementations
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository PermissionRepository) 
        {
            _permissionRepository = PermissionRepository;
        }

        public async Task <IList<Is_Able_To>> getAllUserPermisions()
        {
            return await _permissionRepository.getAllUserPermision();
        }

        public async Task<IList<Role>> getAllRoles()
        {
            return await _permissionRepository.getAllRole();
        }

        public async Task<IList<Permission>> getAllPermisions()
        {
            return await _permissionRepository.getAllPermision();
        }

        public async Task<IList<User>> getAllUsers()
        {
            return await _permissionRepository.getAllUser();
        }

        public Administrator getAdministrator(string email)
        {
            return _permissionRepository.getAdministrator(email);
        }

        public Client getClient(string email)
        {
            return _permissionRepository.getClient(email);
        }

        public Entrepreneur getEntrepreneur(string email)
        {
            return _permissionRepository.getEntrepreneur(email);
        }

        public User getUserByEmail(string email) 
        {
            return _permissionRepository.getUser(email);
        }

        public string getHashByEmail(string email)
        {
            return _permissionRepository.getHash(email);
        }

        public string getEmailByHash(string hash)
        {
            return _permissionRepository.getEmail(hash);
        }

        public async Task<IList<Is_Able_To>> getPermissionsByUser(string email)
        {
            return await _permissionRepository.getUserPermissions(email);
        }

        public void updateUserPermissions(string email, IList<Is_Able_To> permissions)
        {
            _permissionRepository.deleteAllEntries(email);

            for(int i=0; i < permissions.Count(); i++)
            {
                _permissionRepository.addEntry(permissions[i]);
            }
        }

        public async Task addPermission(Is_Able_To permission)
        {
            await _permissionRepository.addPermissionAsync(permission);
        }

        public Is_Able_To searchPermission(string email, int permission, int role)
        {
            return _permissionRepository.getPermission(email, permission, role);
        }
    }
}