using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
namespace EmprendeUCR.Application.PaymentInfos
{
    public interface ISinpeMovilPaymentInfoService
    {
        public Task<SinpeMovilPaymentInfo?> GetSinpeMovilPaymentInfoByIdAsync(int phoneNumber);
        public Task<IEnumerable<SinpeMovilPaymentInfo>> GetSinpeMovilPaymentInfosAsync();
        public Task AddPaymentInfoAsync(SinpeMovilPaymentInfo sinpeMovilPaymentMethod);
        public Task<List<SinpeMovilPaymentInfo>?> GetSinpeMovilPaymentInfosByPaymentInfoIDAsync(List<HasPaymentInfo> list);
        public Task<SinpeMovilPaymentInfo?> GetSinpeMovilPaymentInfoByPaymentInfoID(int paymentInfoID);
    }
}