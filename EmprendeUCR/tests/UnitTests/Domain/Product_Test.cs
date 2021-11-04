using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class Product_Test
    {
        [Fact]
        public void TryverifyProductPrice()
        {
            int Precio = 0;

            Product product = new Product();


            Assert.False(product.setPrice(Precio));


        }

        [Fact]
        public void TryverifyProductMaxPrice()
        {
            int Precio = 2147483647;

            Product product = new Product();


            Assert.True(product.setPrice(Precio));


        }

        [Fact]
        public void TryverifyProductInvalidPrice()
        {
            int Precio = -1;

            Product product = new Product();


            Assert.False(product.setPrice(Precio));

        }

        [Fact]
        public void TryverifyProductvalidCateg()
        {
            int category = 1;

            Product product = new Product();


            Assert.True(product.setCategory(category));

        }

        [Fact]
        public void TryverifyProductInvalidCateg()
        {
            int category = -1;

            Product product = new Product();


            Assert.False(product.setCategory(category));

        }

        [Fact]
        public void TryverifyProductvalidCodeId()
        {
            int code = 1;

            Product product = new Product();

            Assert.True(product.setCodeID(code));

        }

        [Fact]
        public void TryverifyProductInvalidCodeId()
        {
            int code = -2;

            Product product = new Product();


            Assert.False(product.setCodeID(code));

        }


    }
}