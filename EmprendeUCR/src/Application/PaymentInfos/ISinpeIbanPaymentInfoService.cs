using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
namespace EmprendeUCR.Application.PaymentInfos
{
    public interface ISinpeIbanPaymentInfoService
    {
        public Task<SinpeIbanPaymentInfo?> GetSinpeIbanPaymentInfoByIdAsync(string accountNumber);
        public Task<IEnumerable<SinpeIbanPaymentInfo>> GetSinpeIbanPaymentInfosAsync();
        public Task AddPaymentInfoAsync(SinpeIbanPaymentInfo sinpeIbanPaymentMethod);
        public Task<List<SinpeIbanPaymentInfo>?> GetSinpeIbanPaymentInfosByPaymentInfoIDAsync(List<HasPaymentInfo> list);
        public Task<SinpeIbanPaymentInfo?> GetSinpeIbanPaymentInfoByPaymentInfoID(int paymentInfoID);
    }
}