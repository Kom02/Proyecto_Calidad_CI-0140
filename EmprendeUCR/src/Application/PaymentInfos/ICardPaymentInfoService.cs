using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
namespace EmprendeUCR.Application.PaymentInfos
{
    public interface ICardPaymentInfoService
    {
        public Task<CardPaymentInfo?> GetCardPaymentInfoByIdAsync(string accountNumber);
        public Task<IEnumerable<CardPaymentInfo>> GetCardPaymentInfosAsync();
        public Task AddPaymentInfoAsync(CardPaymentInfo cardPaymentMethod);
        public Task<List<CardPaymentInfo>?> GetCardPaymentInfosByPaymentInfoIDAsync(List<HasPaymentInfo> list);
        public Task<CardPaymentInfo?> GetCardPaymentInfoByPaymentInfoID(int paymentInfoID);
    }
}