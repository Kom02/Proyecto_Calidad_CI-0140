using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class RoleTest
    {
        [Fact]
        public void TryCreateRole()
        {
            int id = 1;
            string type = "Cliente";

            Role myRole = new Role
            {
                Id = id,
                Type= type
            };

            Assert.True(id == myRole.Id, "The role id is not the same");
            Assert.True(type == myRole.Type, "The role type is not the same");

        }

        [Fact]
        public void roleNotNull()
        {
            int id = 1;
            string type = "Cliente";

            Role myRole = new Role
            {
                Id = id,
                Type = type
            };

            Assert.NotNull(myRole);

        }
    }
}

/* 
 tests for Role
 PIIB12021-458 List entrepreneur permissions
 PIIB12021-451 Modify entrepreneur permissions
 PIIB12021-450 Remove entrepreneur user permissions
 PIIB12021-452 Add entrepeneur user permissions
 Pair programming: Manfred Carvajal - Jostyn Delgado
*/
