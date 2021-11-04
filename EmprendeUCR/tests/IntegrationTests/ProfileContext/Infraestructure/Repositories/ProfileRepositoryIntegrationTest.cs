using EmprendeUCR.Domain.ProfileContext.Repositories;
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

namespace EmprendeUCR.IntegrationTests.ProfileContext.Infraestructure.Repositories
{
    public class ProfileRepositoryIntegrationTest : IClassFixture<ProfileContextFactory<Startup>>
    {
        private readonly ProfileContextFactory<Startup> _factory;

        public ProfileRepositoryIntegrationTest(ProfileContextFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]

        public async Task verifyGetUserAsync()
        {
            var repository = _factory.Server.Services.GetRequiredService<IProfileRepository>();

            var findUser = await repository.GetUserAsync("cuenta.user@gmail.com");

            findUser.Should().NotBeNull();
        }

        [Fact]
        public async Task verifyGetMemberAsyncAsync()
        {
            var repository = _factory.Server.Services.GetRequiredService<IProfileRepository>();

            var findMember = await repository.GetMemberAsync("add.client@gmail.com");

            findMember.Should().NotBeNull();
        }

        [Fact]
        public async Task verifyUserUpdate()
        {
            var repository = _factory.Server.Services.GetRequiredService<IProfileRepository>();

            User user = new User();

            user.Email = "cuenta.user@gmail.com";
            user.Name = "Pedro";
            user.F_Last_Name = "User";
            user.S_Last_Name = "Test";
            //user.Birth_Date = 1999-07-30;
            user.Province_Name = "Alajuela";
            user.Canton_Name = "Alajuela";
            user.District_Name = "Alajuela";
            user.Email_Confirmation = true;

            var updateUser = await repository.UserUpdate(user);
            updateUser.Should().BeTrue();

           
        }

        [Fact]
        public async Task verifyClientUpdate()
        {
            var repository = _factory.Server.Services.GetRequiredService<IProfileRepository>();

             Client client = new Client();

            client.User_Email = "shop.cart@gmail.com";

             var updateUser = await repository.ClientUpdate(client);
            updateUser.Should().BeTrue();
        }

        [Fact]

        public async Task verifyAddMemberLikes()
        {
            var repository = _factory.Server.Services.GetRequiredService<IProfileRepository>();
            Likes likes = new Likes();

            likes.Members_Email = "add.client@gmail.com";
            likes.Category_Id = 6;

            var addLikes = await repository.AddMemberLikes(likes);

            addLikes.Should().BeTrue();
        }
    }
}
