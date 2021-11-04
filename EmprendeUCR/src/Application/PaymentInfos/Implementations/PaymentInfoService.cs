using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
namespace EmprendeUCR.Application.PaymentInfos.Implementations
{
    internal class PaymentInfoService : IPaymentInfoService
    {
        private readonly IPaymentInfoRepository _paymentInfoRepository;

        public PaymentInfoService(IPaymentInfoRepository paymentInfoRepository)
        {
            _paymentInfoRepository = paymentInfoRepository;
        }
        public async Task<PaymentInfo?> GetPaymentInfoByIdAsync(int id)
        {
            return await _paymentInfoRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<PaymentInfo>> GetPaymentInfosAsync()
        {
            return await _paymentInfoRepository.GetAllAsync();
        }
        public async Task<PaymentInfo?> AddPaymentInfoAsync()
        {
            return await _paymentInfoRepository.AddPaymentInfo();
        }
        public async Task RemovePaymentInfoAsync(int id)
        {
            await _paymentInfoRepository.RemovePaymentInfo(id);
        }
    }
}