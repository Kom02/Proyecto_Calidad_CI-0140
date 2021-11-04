/*
Luis Eduardo Rojas Carrillo - B86875 Pruebas de Unidad e Integración.
Kevin Obando Molina - B55121
EmailConfirmation tests.
*/
using FluentAssertions;
using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;
using System;

namespace EmprendeUCR.UnitTests.Domain
{
    public class EmailConfirmationTest
    {
        [Fact]
        public void TryCreateEmailConfirmation()
        {
            var newEmail = new EmailConfirmation("luis.4.2000@hotmail.com", "apetitos", new DateTime(2016, 7, 15, 3, 15, 0), new DateTime(2016, 7, 15, 3, 15, 0));

            Assert.True("luis.4.2000@hotmail.com" == newEmail.Email, "The email does not the same");
            Assert.True("apetitos" == newEmail.Hash_Code, "The hash_code does not the same");
            Assert.True(new DateTime(2016, 7, 15, 3, 15, 0) == newEmail.Creation_Date, "The creation date does not the same");
            Assert.True(new DateTime(2016, 7, 15, 3, 15, 0) == newEmail.Expiration_Date, "The expiration date does not the same");
        }

        [Fact]
        public void TrySetEmail() 
        {
            var newEmail = new EmailConfirmation();
            newEmail.Email = "luis.4.2000@hotmail.com";
            Assert.True("luis.4.2000@hotmail.com" == newEmail.Email, "The email does not the same");
        }

        [Fact]
        public void TrySetHash()
        {
            var newEmail = new EmailConfirmation();
            newEmail.Hash_Code = "apetitos";
            Assert.True("apetitos" == newEmail.Hash_Code, "The hash_code does not the same");
        }

        [Fact]
        public void TrySetCreationDate()
        {
            var newEmail = new EmailConfirmation();
            newEmail.Creation_Date = new DateTime(2016, 7, 15, 3, 15, 0);
            Assert.True(new DateTime(2016, 7, 15, 3, 15, 0) == newEmail.Creation_Date, "The creation date does not the same");
        }

        [Fact]
        public void TrySetExpirationDate()
        {
            var newEmail = new EmailConfirmation();
            newEmail.Expiration_Date = new DateTime(2016, 7, 15, 3, 15, 0);
            Assert.True(new DateTime(2016, 7, 15, 3, 15, 0) == newEmail.Expiration_Date, "The expiration date does not the same");
        }
    }
}
