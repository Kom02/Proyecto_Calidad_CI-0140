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
    public class CardPaymentMethodServiceTests
    {
        private static IEnumerable<CardPaymentMethod> GetPaymentMethods()
        {
            string[] cardNames = new string[] { "Visa", "Mastercard", "American Express" };
            for (int i = 0; i < cardNames.Length; ++i)
            {
                yield return new CardPaymentMethod(cardNames[i], true);
            }
        }
        [Fact]
        public async Task GetCardPMAsyncShouldReturnCardPM()
        {
            // arrange
            var cardPaymentMethods = GetPaymentMethods().ToList();
            var mockCardPMRepository = new Mock<ICardPaymentMethodRepository>();
            mockCardPMRepository.Setup(repo =>
            repo.GetAllAsync()).ReturnsAsync(cardPaymentMethods);
            var cardPMService = new CardPaymentMethodService(mockCardPMRepository.Object);
            // act
            var results = await cardPMService.GetPaymentMethodsAsync();
            // assert
            results.Should().BeEquivalentTo(cardPaymentMethods);
        }
        [Fact]
        public async Task GetCardPMByIdAsyncWithValidIdShouldReturnPM()
        {
            // arrange
            const string name  = "Visa";
            const bool status = true;
            var CardPM = new CardPaymentMethod(name,status);
            var mockTeamRepository = new Mock<ICardPaymentMethodRepository>();
            mockTeamRepository.Setup(repo =>
            repo.GetByIdAsync(name)).ReturnsAsync(CardPM);
            var cardPMService = new CardPaymentMethodService(mockTeamRepository.Object);
            // act
            var result = await cardPMService.GetPaymentMethodByIdAsync(name);
            // assert
            result.Should().Be(CardPM);
        }

    }
}