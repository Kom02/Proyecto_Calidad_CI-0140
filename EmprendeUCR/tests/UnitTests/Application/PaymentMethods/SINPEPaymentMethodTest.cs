using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using EmprendeUCR.Application.PaymentMethods.Implementations;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentMethods.Repositories;
using Moq;
using Xunit;

namespace EmprendeUCR.UnitTests.Application.PaymentMethods
{
    public class SINPEPaymentMethodTest
    {
        private static IEnumerable<SinpeIbanPaymentMethod> GetPaymentMethods()
        {
            string[] ibanNames = new string[] { "SINPE_IBAN" };
            for (int i = 0; i < ibanNames.Length; ++i)
            {
                yield return new SinpeIbanPaymentMethod(ibanNames[i], true);
            }
        }
        [Fact]
        public async Task GetIbanPMAsyncShouldReturnIbanPM()
        {
            // arrange
            var ibanPaymentMethods = GetPaymentMethods().ToList();
            var mockIbanPMRepository = new Mock<ISinpeIbanPaymentMethodRepository>();
            mockIbanPMRepository.Setup(repo =>
            repo.GetAllAsync()).ReturnsAsync(ibanPaymentMethods);
            var ibanPMService = new SinpeIbanPaymentMethodService(mockIbanPMRepository.Object);
            // act
            var results = await ibanPMService.GetPaymentMethodsAsync();
            // assert
            results.Should().BeEquivalentTo(ibanPaymentMethods);
        }
    }
}