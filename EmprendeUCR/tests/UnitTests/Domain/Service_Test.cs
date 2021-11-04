using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Exceptions;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class ServiceTest
    {
        [Fact]
        public void TryverifyServicePrice()
        {
            int Precio = 0;
            Service service = new Service();
            service.setPrice(Precio);
            Assert.True(service.Price_per_hour == Precio);
        }

        [Fact]
        public void TryverifyServiceMaxPrice()
        {
            int Precio = 2147483647;
            Service service = new Service();
            Assert.True(service.setPrice(Precio));

        }

        [Fact]
        public void TryverifyServcieInvalidPrice()
        {
            int Precio = -1;
            Service service = new Service();
            Assert.False(service.setPrice(Precio));
        }



        [Fact]
        public void TryverifyProductIvalidCateg()
        {
            int category = 1;

            Service service = new Service();

            Assert.True(service.setCategory(category));

        }


        [Fact]
        public void TryverifyProductInvalidCateg()
        {
            int category = -1;

            Service service = new Service();

            Assert.False(service.setCategory(category));

        }


        [Fact]
        public void TryverifyProductvalidCodeId()
        {
            int code = 1;

            Service service = new Service();

            Assert.True(service.setCodeID(code));

        }

        [Fact]
        public void TryverifyProductInvalidCodeId()
        {
            int code = -2;

            Service service = new Service();

            Assert.False(service.setCodeID(code));
        }


    }
}