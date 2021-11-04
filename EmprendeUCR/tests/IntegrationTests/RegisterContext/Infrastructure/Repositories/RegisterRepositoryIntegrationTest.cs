using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using EmprendeUCR.Domain.RegisterContext.Entities;
using EmprendeUCR.Domain.RegisterContext.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using EmprendeUCR_WebApplication;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.IntegrationTests.RegisterContext.Infrastructure.Repositories
{
    public class RegisterRepositoryIntegrationTest : IClassFixture<RegisterContextFactory<Startup>>
    {
        private readonly RegisterContextFactory<Startup> _factory;
        public
        RegisterRepositoryIntegrationTest(RegisterContextFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task addUserAsync()
        {
            User newUser = new User();
            newUser.Email = "nuevoUsuario@correo.com";
            newUser.Name = "Nombre";
            newUser.Birth_Date = DateTime.Today;
            newUser.Canton_Name = "Alajuela";
            newUser.District_Name = "Alajuela";
            newUser.Province_Name = "Alajuela";
            newUser.Email_Confirmation = true;
            newUser.F_Last_Name = "Apellido1";
            newUser.S_Last_Name = "Apellido2";

            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var adingUser = await repository.addUserAsync(newUser);

            adingUser.Should().BeTrue();

            //_factory.SeedDatabaseForTests((DbContext)repository.UnitOfWork);
        }

        [Fact]
        public async Task verifyUserRecord()
        {
            Register register = new Register();
            register.Email = "cuenta.user@gmail.com";//cuenta de super admin
            register.Password = "password";
            // arrange
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            // act
            var userVerify = repository.verifyUserRecord(register);
            // assert
            userVerify.Should().BeTrue();
        }

        [Fact]
        public async Task addCredentials()
        {
            Credentials newCredentials = new Credentials();
            newCredentials.User_Email = "cuenta.user@gmail.com";
            newCredentials.Password = "password";

            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();

            var credenciales = await repository.addCredentialsAsync(newCredentials);

            credenciales.Should().BeTrue();
        }

        [Fact]
        public async Task addEmailConfirmation()
        {
            EmailConfirmation newEmail = new EmailConfirmation();
            newEmail.Expiration_Date = DateTime.Today;
            newEmail.Email = "cuenta.user@gmail.com";
            newEmail.Creation_Date = DateTime.Today;
            newEmail.Hash_Code = "asdjhaiuhfafs";

            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();

            var email = await repository.addEmailConfirmationAsync(newEmail);

            email.Should().BeTrue();
        }

        [Fact]
        public async Task addPhone()
        {
            Phones newPhone = new Phones();
            newPhone.Phone_Number = "12345678";
            newPhone.User_Email = "cuenta.user@gmail.com";

            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();

            var phone = await repository.addPhoneAsync(newPhone);

            phone.Should().BeTrue();
        }

        [Fact]
        public async Task getParentsCategory()
        {
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            IList<Category> lista = await repository.getParents();

            lista.Should().HaveCount(5);
        }

        [Fact]
        public async Task getChildrenOfCategory()
        {
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            IList<Category> lista = await repository.getChildrenOf(4);

            lista.Should().HaveCount(3);
        }

        [Fact]
        public async Task getConfirmationEmail()
        {
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            EmailConfirmation email = await repository.getConfirmationEmail("asdkljaljfha");
            email.Should().NotBeNull();
        }

        [Fact]
        public async Task getUserConfirmByEmail()
        {
            string email = "luise2020@gmail.com";
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var confirmEmail = repository.getUserConfirmEmail(email);

            /*Assert*/
            confirmEmail.Should().NotBeNull();
        }

        [Fact]
        public async Task getAllDistrict()
        {
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            IList<District> list = await repository.getAllDistricts();

            /*Assert*/
            list.Should().HaveCount(487);
        }

        [Fact]
        public async Task getAllCantons()
        {
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            IList<Canton> list = await repository.getAllCantons();

            /*Assert*/
            list.Should().HaveCount(82);
        }

        [Fact]
        public async Task getAllProvinces()
        {
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            IList<Province> list = await repository.getAllProvinces();

            /*Assert*/
            list.Should().HaveCount(7);
        }

        [Fact]
        public async Task getAllCategory()
        {
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            IList<Category> list = await repository.getAllCategories();

            /*Assert*/
            list.Should().HaveCount(8);
        }

        [Fact]
        public async Task updateUser()
        {
            User newUser = new User();
            newUser.Email = "update.user@gmail.com";
            newUser.Name = "Luis Eduardo";
            newUser.Birth_Date = DateTime.Today;
            newUser.Canton_Name = "Alajuela";
            newUser.District_Name = "Alajuela";
            newUser.Province_Name = "Alajuela";
            newUser.Email_Confirmation = true;
            newUser.F_Last_Name = "Rojas";
            newUser.S_Last_Name = "Carrillo";
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var updated = await repository.updateUserAsync(newUser);

            /*Assert*/
            updated.Should().BeTrue();
        }

        [Fact]
        public async Task addMembers()
        {
            Members newMembers = new Members();
            newMembers.Direction = "Por allá";
            newMembers.Lat = 2.8;
            newMembers.Long = 33.19;
            newMembers.Score = 5;
            newMembers.User_Email = "add.member@gmail.com";
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var addingMember = await repository.addMembersAsync(newMembers);

            /*Assert*/
            addingMember.Should().BeTrue();
        }

        [Fact]
        public async Task addClientAsync()
        {
            Client newClient = new Client();
            newClient.User_Email = "add.client@gmail.com";
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var addClient = await repository.addClientAsync(newClient);

            /*Assert*/
            addClient.Should().BeTrue();
        }

        [Fact]
        public async Task addShoppingCart()
        {
            ShoppingCart newCart = new ShoppingCart();
            newCart.Email = "shop.cart@gmail.com";
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var addCart = await repository.addShoppingCartAsync(newCart);

            /*Assert*/
            addCart.Should().BeTrue();
        }

        [Fact]
        public async Task addLikes()
        {
            Likes newLike = new Likes();
            newLike.Category_Id = 10;
            newLike.Members_Email = "add.entrepreneur@gmail.com";
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var addLike = await repository.addLikesAsync(newLike);
            /*ASSERT*/
            addLike.Should().BeTrue();
        }

        [Fact]
        public async Task addEntrepreneur()
        {
            Entrepreneur entrepreneur = new Entrepreneur();
            entrepreneur.Presentation = "Hola soy un emprendedor";
            entrepreneur.User_Email = "add.entrepreneur@gmail.com";
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var addEntrepreneur = await repository.addEntrepreneurAsync(entrepreneur);
            /*Assert*/
            addEntrepreneur.Should().BeTrue();
        }

        [Fact]
        public async Task addAdministrator() 
        {
            Administrator newAdmin = new Administrator();
            newAdmin.User_Email = "add.admin@gmail.com";
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var addAdmin = await repository.addAdministratorAsync(newAdmin);
            /*Assert*/
            addAdmin.Should().BeTrue();
        }

        [Fact]
        public async Task getListCantons() 
        {
            string province = "Alajuela";

            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            IList<Canton> list = repository.getListCantons(province);
            /*Assert*/
            list.Should().HaveCount(16);
        }

        [Fact]
        public async Task getListDistricts()
        {
            string canton = "Alajuela";

            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            IList<District> list = repository.getListDistrics(canton);
            /*Assert*/
            list.Should().HaveCount(13);
        }

        [Fact]
        public async Task getActiveAdmin()  //add?
        {
            ActiveAdministrators newAdmin = new ActiveAdministrators();
            newAdmin.Active = true;
            newAdmin.Confirm = true;
            newAdmin.Creation_Date = DateTime.Today;
            newAdmin.Email = "cuenta2.admin@gmail.com";
            newAdmin.Response = true;
            newAdmin.Response_Date = DateTime.Today;

            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();

            var addAdmin = await repository.addActiveAdministrator(newAdmin);
            /*Assert*/
            addAdmin.Should().BeTrue();
        }

        [Fact]
        public async Task verifyPastAdmin() 
        {
            string email = "cuenta.admin@gmail.com";
            var repository = _factory.Server.Services.GetRequiredService<IRegisterRepository>();
            var verified = await repository.verifyPastAdmin(email);
            /*Assert*/
            verified.Should().BeTrue();
        }
    }
}

/*PIIB12021 - 15
Registration Data
Pruebas de integracición del registro de datos
Isaac Herrera B43332
Johel Phillips B75821
*/
