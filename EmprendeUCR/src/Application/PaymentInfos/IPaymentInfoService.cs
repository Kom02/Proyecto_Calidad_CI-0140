using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
namespace EmprendeUCR.Application.PaymentInfos
{
    public interface IPaymentInfoService
    {
        public Task<PaymentInfo?> GetPaymentInfoByIdAsync(int id);
        public Task<IEnumerable<PaymentInfo>> GetPaymentInfosAsync();
        public Task<PaymentInfo?> AddPaymentInfoAsync();
        public Task RemovePaymentInfoAsync(int id);
    }
}