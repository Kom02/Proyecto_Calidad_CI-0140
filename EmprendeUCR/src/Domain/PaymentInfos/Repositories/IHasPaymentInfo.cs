using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;

namespace EmprendeUCR.Domain.PaymentInfos.Repositories
{
    public interface IHasPaymentInfoRepository
    {
        Task SaveAsync(HasPaymentInfo hasPaymentInfo);
        Task<IEnumerable<HasPaymentInfo>> GetAllAsync();
        Task AddHasPaymentInfo(HasPaymentInfo hasPaymentInfo);
    }
}
