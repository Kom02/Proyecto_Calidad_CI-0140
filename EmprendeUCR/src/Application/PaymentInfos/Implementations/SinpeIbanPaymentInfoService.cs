using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
namespace EmprendeUCR.Application.PaymentInfos.Implementations
{
    internal class SinpeIbanPaymentInfoService : ISinpeIbanPaymentInfoService
    {
        private readonly ISinpeIbanPaymentInfoRepository _sinpeIbanPaymentInfoRepository;
        public SinpeIbanPaymentInfoService(ISinpeIbanPaymentInfoRepository sinpeIbanPaymentInfoRepository)
        {
            _sinpeIbanPaymentInfoRepository = sinpeIbanPaymentInfoRepository;
        }
        public async Task AddPaymentInfoAsync(SinpeIbanPaymentInfo sinpeIbanPaymentInfo)
        {
            await _sinpeIbanPaymentInfoRepository.AddPaymentInfo(sinpeIbanPaymentInfo);
        }
        public async Task<SinpeIbanPaymentInfo?> GetSinpeIbanPaymentInfoByIdAsync(string accountNumber)
        {
            return await _sinpeIbanPaymentInfoRepository.GetByIdAsync(accountNumber);
        }

        public async Task<IEnumerable<SinpeIbanPaymentInfo>> GetSinpeIbanPaymentInfosAsync()
        {
            return await _sinpeIbanPaymentInfoRepository.GetAllAsync();
        }
        public async Task<SinpeIbanPaymentInfo> GetSinpeIbanPaymentInfoByPaymentInfoID(int paymentInfoID)
        {
            string ID=paymentInfoID.ToString();
            return await _sinpeIbanPaymentInfoRepository.GetByPaymentInfoID(paymentInfoID);
        }

        public async Task<List<SinpeIbanPaymentInfo>> GetSinpeIbanPaymentInfosByPaymentInfoIDAsync(List<HasPaymentInfo> list)
        {
            List<SinpeIbanPaymentInfo> asociateSinpeIban = new();
            for (int i = 0; i < list.Length(); i++)
            {
                var add = await GetSinpeIbanPaymentInfoByPaymentInfoID(list[i].Payment_Info_ID);
                if (add != null)
                {
                    asociateSinpeIban.Add(add);
                }
            }
            return asociateSinpeIban;
        }
    }
}