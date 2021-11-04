using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class PermissionTest
    {
        [Fact]
        public void TryCreatePermissionComplete()
        {
            var newPermission = new Permission(0, 0, "permiso prueba");
            Assert.True(newPermission != null, "The new permission is equal to null");
        }

        [Fact]
        public void TryCreatePermissionEmpty()
        {
            var newPermission = new Permission();
            
            Assert.True(newPermission != null, "The new permission is equal to null");
            Assert.True(newPermission.Id == int.MinValue,"The new permission id is not min int");
            Assert.True(newPermission.Role_Id == int.MinValue, "The new permission role id is not min int");
            Assert.True(newPermission.Description == null, "The new permission description is not null");
        }

        [Fact]
        public void TrySetId()
        {
            int permisoId = 5;
            var newPermission = new Permission();
            newPermission.Id = permisoId;
            Assert.True(newPermission.Id == permisoId, "The permission id is not the same");
        }

        [Fact]
        public void TrySetRoleId()
        {
            int roleId = 10;
            var newPermission = new Permission();
            newPermission.Role_Id = roleId;
            Assert.True(newPermission.Role_Id == roleId, "The role id id is not the same");
        }

        [Fact]
        public void TrySetDescription()
        {
            string des = "Nueva descripción"; 
            var newPermission = new Permission();
            newPermission.Description = des;
            Assert.True(newPermission.Description == des, "The description is not the same");
        }


    }
}


/*
Jostyn Delgado - B82568  ___ Pruebas de Unidad e Integración.
Permission tests.
*/
