using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
namespace EmprendeUCR.Application.PaymentInfos.Implementations
{
    internal class SinpeMovilPaymentInfoService : ISinpeMovilPaymentInfoService
    {
        private readonly ISinpeMovilPaymentInfoRepository _sinpeMovilPaymentInfoRepository;

        public SinpeMovilPaymentInfoService(ISinpeMovilPaymentInfoRepository sinpeMovilPaymentInfoRepository)
        {
            _sinpeMovilPaymentInfoRepository = sinpeMovilPaymentInfoRepository;
        }
        public async Task AddPaymentInfoAsync(SinpeMovilPaymentInfo sinpeMovilPaymentInfo)
        {
            await _sinpeMovilPaymentInfoRepository.AddPaymentInfo(sinpeMovilPaymentInfo);
        }

        public Task<SinpeMovilPaymentInfo> GetCardPaymentInfoByPaymentInfoID(int paymentInfoID)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SinpeMovilPaymentInfo>> GetCardPaymentInfosByPaymentInfoIDAsync(List<HasPaymentInfo> list)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SinpeMovilPaymentInfo?> GetSinpeMovilPaymentInfoByIdAsync(int phoneNumber)
        {
            return await _sinpeMovilPaymentInfoRepository.GetByIdAsync(phoneNumber);
        }
        public async Task<IEnumerable<SinpeMovilPaymentInfo>> GetSinpeMovilPaymentInfosAsync()
        {
            return await _sinpeMovilPaymentInfoRepository.GetAllAsync();
        }
        public async Task<SinpeMovilPaymentInfo> GetSinpeMovilPaymentInfoByPaymentInfoID(int paymentInfoID)
        {
            return await _sinpeMovilPaymentInfoRepository.GetByPaymentInfoID(paymentInfoID);
        }

        public async Task<List<SinpeMovilPaymentInfo>> GetSinpeMovilPaymentInfosByPaymentInfoIDAsync(List<HasPaymentInfo> list)
        {
            List<SinpeMovilPaymentInfo> asociateSinpeMovil = new();
            for (int i = 0; i < list.Length(); i++)
            {
                var add = await GetSinpeMovilPaymentInfoByPaymentInfoID(list[i].Payment_Info_ID);
                if (add != null)
                {
                    asociateSinpeMovil.Add(add);
                }
            }
            return asociateSinpeMovil;
        }
    }
}