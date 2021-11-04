using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentInfos.Entities;
namespace EmprendeUCR.Application.PaymentMethods
{
    public interface ICardPaymentMethodService
    {
        Task<IEnumerable<CardPaymentMethod>> GetPaymentMethodsAsync();
        Task<CardPaymentMethod?> GetPaymentMethodByIdAsync(string name);
        Task ChangeStatusToPaymentMethodAsync(CardPaymentMethod cardPaymentMethod);
        Task AddPaymentInfoToPaymentMethodAsync(CardPaymentMethod cardPaymentMethod,
            CardPaymentInfo cardPaymentInfo);
        Task DeletePaymentInfoAndRemoveFromPaymentMethodAsync(CardPaymentMethod cardPaymentMethod,
            CardPaymentInfo cardPaymentInfo);
    }
}