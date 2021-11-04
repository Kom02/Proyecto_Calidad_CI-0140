using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;

namespace EmprendeUCR.Domain.PaymentInfos.Repositories
{
    public interface ISinpeIbanPaymentInfoRepository
    {
        Task SaveAsync(SinpeIbanPaymentInfo sinpeIbanPaymentInfo);
        Task<IEnumerable<SinpeIbanPaymentInfo>> GetAllAsync();
        Task<SinpeIbanPaymentInfo?> GetByIdAsync(string accountNumber);
        Task AddPaymentInfo(SinpeIbanPaymentInfo sinpeIbanPaymentInfo);
        Task<SinpeIbanPaymentInfo?> GetByPaymentInfoID(int id);
    }
}
