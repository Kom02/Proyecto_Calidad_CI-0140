using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class Is_Able_To_Test
    {
        [Fact]
        public void TryCreateIs_Able_To()
        {
            string email = "cliente@gmail.com";
            int role_id = 1;
            int permission_id = 1;

            Is_Able_To my_is_Able_To = new Is_Able_To
            {
                Email = email,
                Role_Id = role_id,
                Permission_Id = permission_id
            };

            Assert.True(email == my_is_Able_To.Email, "The email is not the same");
            Assert.True(role_id == my_is_Able_To.Role_Id, "The role id is not the same");
            Assert.True(permission_id == my_is_Able_To.Permission_Id, "The permission id is not the same");

        }

        [Fact]
        public void Is_Able_To_NotNull()
        {
            string email = "cliente@gmail.com";
            int role_id = 1;
            int permission_id = 1;

            Is_Able_To my_is_Able_To = new Is_Able_To
            {
                Email = email,
                Role_Id = role_id,
                Permission_Id = permission_id
            };

            Assert.NotNull(my_is_Able_To);

        }
    }
}

/* 
 tests for Is_Able_To
 PIIB12021-458 List entrepreneur permissions
 PIIB12021-451 Modify entrepreneur permissions
 PIIB12021-450 Remove entrepreneur user permissions
 PIIB12021-452 Add entrepeneur user permissions
 Pair programming: Manfred Carvajal - Jostyn Delgado
*/
