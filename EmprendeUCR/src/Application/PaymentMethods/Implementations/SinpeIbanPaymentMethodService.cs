using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentMethods.Repositories;
namespace EmprendeUCR.Application.PaymentMethods.Implementations
{
    public class SinpeIbanPaymentMethodService : ISinpeIbanPaymentMethodService
    {
        private readonly ISinpeIbanPaymentMethodRepository _sinpeIbanPaymentMethodRepository;
        public SinpeIbanPaymentMethodService(ISinpeIbanPaymentMethodRepository sinpeIbanPaymentMethodRepository)
        {
            _sinpeIbanPaymentMethodRepository = sinpeIbanPaymentMethodRepository;
        }
        public async Task<SinpeIbanPaymentMethod?> GetPaymentMethodByIdAsync(string name)
        {
            return await _sinpeIbanPaymentMethodRepository.GetByIdAsync(name);
        }
        public async Task<IEnumerable<SinpeIbanPaymentMethod>> GetPaymentMethodsAsync()
        {
            return await _sinpeIbanPaymentMethodRepository.GetAllAsync();
        }
        public async Task ChangeStatusToPaymentMethodAsync(SinpeIbanPaymentMethod sinpeIbanPaymentMethod)
        {
            sinpeIbanPaymentMethod.ChangeStatus();
            await _sinpeIbanPaymentMethodRepository.SaveAsync(sinpeIbanPaymentMethod);
        }
        public async Task AddPaymentInfoToPaymentMethodAsync(SinpeIbanPaymentMethod sinpeIbanPaymentMethod, SinpeIbanPaymentInfo sinpeIbanPaymentInfo)
        {
            sinpeIbanPaymentMethod.AddSinpeIbanPaymentInfo(sinpeIbanPaymentInfo);
            await _sinpeIbanPaymentMethodRepository.SaveAsync(sinpeIbanPaymentMethod);
        }
        public async Task DeletePaymentInfoAndRemoveFromPaymentMethodAsync(SinpeIbanPaymentMethod sinpeIbanPaymentMethod, SinpeIbanPaymentInfo sinpeIbanPaymentInfo)
        {
            sinpeIbanPaymentMethod.RemovePhonePaymentInfo(sinpeIbanPaymentInfo);
            await _sinpeIbanPaymentMethodRepository.DeletePaymentInformation(sinpeIbanPaymentInfo);
            await _sinpeIbanPaymentMethodRepository.SaveAsync(sinpeIbanPaymentMethod);
        }
    }
}