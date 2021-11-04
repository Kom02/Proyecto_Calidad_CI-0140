using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentInfos.Entities;
namespace EmprendeUCR.Application.PaymentMethods
{
    public interface ISinpeIbanPaymentMethodService
    {
        Task<IEnumerable<SinpeIbanPaymentMethod>> GetPaymentMethodsAsync();
        Task<SinpeIbanPaymentMethod?> GetPaymentMethodByIdAsync(string name);
        Task ChangeStatusToPaymentMethodAsync(SinpeIbanPaymentMethod sinpeIbanPaymentMethod);
        Task AddPaymentInfoToPaymentMethodAsync(SinpeIbanPaymentMethod sinpeIbanPaymentMethod,
            SinpeIbanPaymentInfo sinpeIbanPaymentInfo);
        Task DeletePaymentInfoAndRemoveFromPaymentMethodAsync(SinpeIbanPaymentMethod sinpeIbanPaymentMethod,
            SinpeIbanPaymentInfo sinpeIbanPaymentInfo);
    }
}