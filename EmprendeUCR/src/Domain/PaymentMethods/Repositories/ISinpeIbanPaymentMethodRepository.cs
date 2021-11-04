using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
namespace EmprendeUCR.Domain.PaymentMethods.Repositories
{
    public interface ISinpeIbanPaymentMethodRepository
    {
        Task SaveAsync(SinpeIbanPaymentMethod sinpeIbanPaymentMethod);
        Task<IEnumerable<SinpeIbanPaymentMethod>> GetAllAsync();
        Task<SinpeIbanPaymentMethod?> GetByIdAsync(string name);
        Task DeletePaymentInformation(SinpeIbanPaymentInfo sinpeIbanPaymentInfo);
    }
}