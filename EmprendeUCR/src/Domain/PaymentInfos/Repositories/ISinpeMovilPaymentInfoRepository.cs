using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;

namespace EmprendeUCR.Domain.PaymentInfos.Repositories
{
    public interface ISinpeMovilPaymentInfoRepository
    {
        Task SaveAsync(SinpeMovilPaymentInfo sinpeMovilPaymentInfo);
        Task<IEnumerable<SinpeMovilPaymentInfo>> GetAllAsync();
        Task<SinpeMovilPaymentInfo?> GetByIdAsync(int phoneNumber);
        Task AddPaymentInfo(SinpeMovilPaymentInfo sinpeMovilPaymentInfo);
        Task<SinpeMovilPaymentInfo?> GetByPaymentInfoID(int id);
    }
}
