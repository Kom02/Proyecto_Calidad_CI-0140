using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentMethods.Repositories;
namespace EmprendeUCR.Application.PaymentMethods.Implementations
{
    internal class SinpeMovilPaymentMethodService : ISinpeMovilPaymentMethodService
    {
        private readonly ISinpeMovilPaymentMethodRepository _sinpeMovilPaymentMethodRepository;
        public SinpeMovilPaymentMethodService(ISinpeMovilPaymentMethodRepository sinpeMovilPaymentMethodRepository)
        {
            _sinpeMovilPaymentMethodRepository = sinpeMovilPaymentMethodRepository;
        }
        public async Task<SinpeMovilPaymentMethod?> GetPaymentMethodByIdAsync(string name)
        {
            return await _sinpeMovilPaymentMethodRepository.GetByIdAsync(name);
        }
        public async Task<IEnumerable<SinpeMovilPaymentMethod>> GetPaymentMethodsAsync()
        {
            return await _sinpeMovilPaymentMethodRepository.GetAllAsync();
        }

        public async Task ChangeStatusToPaymentMethodAsync(SinpeMovilPaymentMethod sinpeMovilPaymentMethod)
        {
            sinpeMovilPaymentMethod.ChangeStatus();
            await _sinpeMovilPaymentMethodRepository.SaveAsync(sinpeMovilPaymentMethod);
        }
        public async Task AddPaymentInfoToPaymentMethodAsync(SinpeMovilPaymentMethod sinpeMovilPaymentMethod, SinpeMovilPaymentInfo sinpeMovilPaymentInfo)
        {
            sinpeMovilPaymentMethod.AddSinpeMovilPaymentInfo(sinpeMovilPaymentInfo);
            await _sinpeMovilPaymentMethodRepository.SaveAsync(sinpeMovilPaymentMethod);
        }

        public async Task DeletePaymentInfoAndRemoveFromPaymentMethodAsync(SinpeMovilPaymentMethod sinpeMovilPaymentMethod, SinpeMovilPaymentInfo sinpeMovilPaymentInfo)
        {
            sinpeMovilPaymentMethod.RemovePhonePaymentInfo(sinpeMovilPaymentInfo);
            await _sinpeMovilPaymentMethodRepository.DeletePaymentInformation(sinpeMovilPaymentInfo);
            await _sinpeMovilPaymentMethodRepository.SaveAsync(sinpeMovilPaymentMethod);
        }
    }
}