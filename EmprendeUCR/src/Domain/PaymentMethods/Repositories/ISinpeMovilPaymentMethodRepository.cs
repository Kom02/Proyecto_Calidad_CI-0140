using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
namespace EmprendeUCR.Domain.PaymentMethods.Repositories
{
    public interface ISinpeMovilPaymentMethodRepository
    {
        Task SaveAsync(SinpeMovilPaymentMethod sinpeMovilPaymentMethod);
        Task<IEnumerable<SinpeMovilPaymentMethod>> GetAllAsync();
        Task<SinpeMovilPaymentMethod?> GetByIdAsync(string name);
        Task DeletePaymentInformation(SinpeMovilPaymentInfo sinpeMovilPaymentInfo);
    }
}