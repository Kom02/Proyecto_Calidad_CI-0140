using FluentAssertions;
using Xunit;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.Core.Helpers;

namespace EmprendeUCR.UnitTests.Domain.PaymentMethods.Entities
{
    public class CardPaymentMethodTests
    {
        private static readonly string Name_Payment_Method = CardPaymentMethod.TryCreateName("Visa").Success();
        private static readonly bool Status_Payment_info = CardPaymentMethod.TryCreateValidStatus(true).Success();
        //private static readonly string Name_PaymentInfo2 = CardPaymentMethod.TryCreateName("MasterCard").Success();

        [Fact]
        public void CreateCardPaymentMethodCorrectly()
        {
            // arrange
            var paymentMethod = new CardPaymentMethod(Name_Payment_Method,Status_Payment_info);
            // act
            paymentMethod.ChangeStatus();
            // assert
            paymentMethod.Status.Should().Be(false);
        }

        //agregar un cardPaymentInfo a la lista
        //CPInfo = new CardPaymentInfo("876256398026756", 300, "Visa");
        //private static readonly string PaymentInfo = CardPaymentMethod.AddCardPaymentInfo(CPInfo).Success();

        //agregar un cardPaymentInfo "nulo"
        //CardPaymentInfo CPInfo2 = new CardPaymentInfo();
        //private static readonly string PaymentInfo2 = CardPaymentMethod.AddCardPaymentInfo(CPInfo2).Success();

        //agregar un cardPaymentInfo repetido a la lista
        //private static readonly string PaymentInfo3 = CardPaymentMethod.AddCardPaymentInfo(CPInfo).Success();


        //eliminar un cardPaymentInfo de la lista
        //private static readonly string deletePaymentInfo = CardPaymentMethod.RemovePhonePaymentInfo(CPInfo).Success();

        //eliminar un cardPaymentInfo nulo de la lista
        //private static readonly string deletePaymentInfo2 = CardPaymentMethod.RemovePhonePaymentInfo(null).Success();

        //eliminar un cardPaymentInfo que no se encuentra en la lista
        //CardPaymentInfo CPInfo3 = new CardPaymentInfo("736284759039485", 299, "Visa");
        //private static readonly string deletePaymentInfo3 = CardPaymentMethod.RemovePhonePaymentInfo(CPInfo3).Success();


    }
}
