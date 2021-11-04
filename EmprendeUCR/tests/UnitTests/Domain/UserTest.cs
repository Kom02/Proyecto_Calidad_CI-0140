using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;
using System;

namespace EmprendeUCR.UnitTests.Domain
{
    public class UserTest
    {
        [Fact]
        public void EmailGetSet()
        {
            string email = "nombre@correo.com";
            User u = new User()
            {
                Email = email
            };
            Assert.True(email == u.Email, "Values don't match");
        }

        [Fact]
        public void NameGetSet()
        {
            string name = "nombre";
            User u = new User()
            {
                Name = name
            };
            Assert.True(name == u.Name, "Values don't match");
        }

        [Fact]
        public void FLastNameGetSet()
        {
            string f_last_name = "apellido1";
            User u = new User()
            {
                F_Last_Name = f_last_name
            };
            Assert.True(f_last_name == u.F_Last_Name, "Values don't match");
        }

        [Fact]
        public void SLastNameGetSet()
        {
            string s_last_name = "apellido2";
            User u = new User()
            {
                S_Last_Name = s_last_name
            };
            Assert.True(s_last_name == u.S_Last_Name, "Values don't match");
        }

        [Fact]
        public void ProvinceGetSet()
        {
            string province = "provincia";
            User u = new User()
            {
                Province_Name = province
            };
            Assert.True(province == u.Province_Name, "Values don't match");
        }

        [Fact]
        public void CantonGetSet()
        {
            string canton = "cantón";
            User u = new User()
            {
                Canton_Name = canton
            };
            Assert.True(canton == u.Canton_Name, "Values don't match");
        }

        [Fact]
        public void DistrictGetSet()
        {
            string district = "distrito";
            User u = new User()
            {
                District_Name = district
            };
            Assert.True(district == u.District_Name, "Values don't match");
        }

        [Fact]
        public void EmailConfirmationGetSet()
        {
            bool emailConfirmation = true;
            User u = new User()
            {
                Email_Confirmation = emailConfirmation
            };
            Assert.True(emailConfirmation == u.Email_Confirmation, "Values don't match");
        }

        [Fact]
        public void DateGetSet()
        {
            DateTime date = DateTime.Now;
            User u = new User()
            {
                Birth_Date = date
            };
            Assert.True(date == u.Birth_Date, "Values don't match");
        }

        [Fact]
        public void PhotoGetSet()
        {
            byte[] array = { 0, 1, 2};
            User u = new User()
            {
                Photo = array
            };
            Assert.True(array == u.Photo, "Values don't match");
        }
    }
}

// José Isaac Herrera - B43332 Pruebas de Unidad e Integración.
// User tests.