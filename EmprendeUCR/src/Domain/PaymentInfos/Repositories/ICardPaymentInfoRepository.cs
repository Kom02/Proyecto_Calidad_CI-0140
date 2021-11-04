using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;

namespace EmprendeUCR.Domain.PaymentInfos.Repositories
{
    public interface ICardPaymentInfoRepository
    {
        Task SaveAsync(CardPaymentInfo sinpeIbanPaymentInfo);
        Task<IEnumerable<CardPaymentInfo>> GetAllAsync();
        Task<CardPaymentInfo?> GetByIdAsync(string accountNumber);
        Task AddPaymentInfo(CardPaymentInfo sinpeIbanPaymentInfo);
        Task<CardPaymentInfo?> GetByPaymentInfoID(int id);
    }
}
