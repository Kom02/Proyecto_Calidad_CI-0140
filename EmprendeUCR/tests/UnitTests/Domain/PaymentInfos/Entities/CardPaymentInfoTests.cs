using FluentAssertions;
using Xunit;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.Core.Helpers;

namespace EmprendeUCR.UnitTests.Domain.PaymentInfos.Entities
{
    public class CardPaymentInfoTests
    {

        private static readonly string Name_Payment_Method = CardPaymentInfo.TryCreate("Visa").Success();
        private static readonly string Account_Number = CardPaymentInfo.TryCreateAccount("2222222222222222222222").Success();
        private static readonly CardPaymentMethod cardPaymentMethod = new CardPaymentMethod(Name_Payment_Method, true);
        private static readonly PaymentInfo paymentInfo = new PaymentInfo(200);

        [Fact]
        public void CreateCardPaymentInfoCorrectly()
        {
            // arrange
            var asignPayment = new CardPaymentInfo(Account_Number,paymentInfo.ID,Name_Payment_Method);
            // act
            asignPayment.AssignPaymentMethod(cardPaymentMethod);
            // assert
            asignPayment.CardPaymentMethod.Should().Be(cardPaymentMethod);
        }
    }
}
