using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentInfos.Entities;
namespace EmprendeUCR.Domain.PaymentMethods.Repositories
{
    public interface ICardPaymentMethodRepository
    {
        Task SaveAsync(CardPaymentMethod cardPaymentMethod);
        Task<IEnumerable<CardPaymentMethod>> GetAllAsync();
        Task<CardPaymentMethod?> GetByIdAsync(string name);
        Task DeletePaymentInformation(CardPaymentInfo cardPaymentInfo);
    }
}