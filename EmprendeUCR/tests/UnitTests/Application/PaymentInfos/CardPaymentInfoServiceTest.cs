//User story: PIIB12021 - 336 Be able to add payment methods to my profile.
//Task: PIIB12021 - 469 Unit and integration testing
//Jean Quesada Abarca 50%
//Hellen Fuentes Artavia 50%

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using EmprendeUCR.Application.PaymentInfos.Implementations;
using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
using Moq;
using Xunit;

namespace EmprendeUCR.UnitTests.Application.PaymentInfos
{
    public class CardPaymentInfoServiceTest
    {
        private static IEnumerable<CardPaymentInfo> GetCardsPaymentInfos()
        {
            const int amountOfCards = 10000;
            for (int i =0; i < amountOfCards; i++)
            {
                yield return new CardPaymentInfo();
            }
        }
        [Fact]
        public async Task GetCardPaymentInfosAsyncShouldReturnCardPaymentInfos()
        {// arrange
            var cardsInfo = GetCardsPaymentInfos().ToList();
            var mockTeamRepository = new Mock<ICardPaymentInfoRepository>();
            mockTeamRepository.Setup(repo =>
            repo.GetAllAsync()).ReturnsAsync(cardsInfo);
            var teamService = new CardPaymentInfoService(mockTeamRepository.Object);
            // act
            var results = await teamService.GetCardPaymentInfosAsync();
            // assert
            results.Should().BeEquivalentTo(cardsInfo);
        }

        public async Task GetPaymentInfoByIdAsyncWithValidIdShouldReturnPaymentInfo()
        {
            // arrange
            var name = CardPaymentInfo.TryCreate("VISA_PARABRISA");
            var accountN = CardPaymentInfo.TryCreateAccount("1234567899765432112345");
            const int id = 1;
            var paymentInfo = new CardPaymentInfo(accountN.ToString(), paymentInfoID: id, name.ToString());
            var mockTeamRepository = new Mock<ICardPaymentInfoRepository>();
            mockTeamRepository.Setup(repo =>
            repo.GetByPaymentInfoID(id)).ReturnsAsync(paymentInfo);
            var paymentInfoService = new CardPaymentInfoService(mockTeamRepository.Object);
            // act
            var result = await paymentInfoService.GetCardPaymentInfoByPaymentInfoID(id);
            // assert
            result.Should().Be(paymentInfo);
        }

    }
}
