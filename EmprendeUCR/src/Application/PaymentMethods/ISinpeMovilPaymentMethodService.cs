using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentInfos.Entities;
namespace EmprendeUCR.Application.PaymentMethods
{
    public interface ISinpeMovilPaymentMethodService
    {
        Task<IEnumerable<SinpeMovilPaymentMethod>> GetPaymentMethodsAsync();
        Task<SinpeMovilPaymentMethod?> GetPaymentMethodByIdAsync(string name);
        Task ChangeStatusToPaymentMethodAsync(SinpeMovilPaymentMethod sinpeMovilPaymentMethod);
        Task AddPaymentInfoToPaymentMethodAsync(SinpeMovilPaymentMethod sinpeMovilPaymentMethod, 
            SinpeMovilPaymentInfo sinpeMovilPaymentInfo);
        Task DeletePaymentInfoAndRemoveFromPaymentMethodAsync(SinpeMovilPaymentMethod sinpeMovilPaymentMethod,
            SinpeMovilPaymentInfo sinpeMovilPaymentInfo);
    }
}