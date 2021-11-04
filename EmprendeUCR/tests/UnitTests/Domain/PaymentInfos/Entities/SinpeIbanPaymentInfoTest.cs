using FluentAssertions;
using Xunit;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.Core.Helpers;

namespace EmprendeUCR.UnitTests.Domain.PaymentInfos.Entities
{
    public class SinpeIbanPaymentInfoTest
    {
        private static readonly string Name_Payment_Method = SinpeIbanPaymentInfo.TryCreate("Fedex").Success();
        private static readonly string Account_Number = SinpeIbanPaymentInfo.TryCreateAccount("2222222222222222222222").Success();
        private static readonly SinpeIbanPaymentMethod sinpeIbanPaymentMethod = new SinpeIbanPaymentMethod(Name_Payment_Method, true);
        private static readonly PaymentInfo paymentInfo = new PaymentInfo(210);

        [Fact]
        public void CreateCardPaymentInfoCorrectly()
        {
            // arrange
            var asignPayment = new SinpeIbanPaymentInfo(Account_Number, paymentInfo.ID, Name_Payment_Method);
            // act
            asignPayment.AssignPaymentMethod(sinpeIbanPaymentMethod);
            // assert
            asignPayment.SinpeIbanPaymentMethod.Should().Be(sinpeIbanPaymentMethod);
        }
    }
}